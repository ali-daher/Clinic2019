using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clinic.Data;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Clinic.Helpers;
using System.Text;
using Clinic.Email;
using Clinic.Services;

namespace Clinic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSendGridEmailSender();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            //Enable CORS
            services.AddCors(options=>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowCredentials().Build();
                });
            });

            //Connect to DataBase

            var connString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString));

            //We are using Identity Framework for registration

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //Configure strongly tyoed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //creating a variable holding all the settings from appSettingsSection
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //Authentication Middleware
            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidIssuer = appSettings.Site,
                     ValidAudience = appSettings.Audience,
                     IssuerSigningKey = new SymmetricSecurityKey(key)
                 };
            });

            services.AddAuthorization(options=> {
                options.AddPolicy("RequireLoggedIn",policy=>policy.RequireRole("Admin","Doctor","Assistant","Patient","Insurance_company").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin").RequireAuthenticatedUser());
                options.AddPolicy("RequireDoctorRole", policy => policy.RequireRole("Doctor").RequireAuthenticatedUser());
                options.AddPolicy("RequireAssistantRole", policy => policy.RequireRole("Assistant").RequireAuthenticatedUser());
                options.AddPolicy("RequirePatientRole", policy => policy.RequireRole("Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireInsuranceRole", policy => policy.RequireRole("Insurance_company").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminDoctorRole", policy => policy.RequireRole("Admin","Doctor").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminPatientRole", policy => policy.RequireRole("Admin", "Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminAssistantRole", policy => policy.RequireRole("Admin", "Assistant").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminInsuranceRole", policy => policy.RequireRole("Admin", "Insurance_company").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminDoctorPatientRole", policy => policy.RequireRole("Admin", "Doctor", "Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminDoctorAssistantRole", policy => policy.RequireRole("Admin", "Doctor", "Assistant").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminDoctorAssistantPatientRole", policy => policy.RequireRole("Admin", "Doctor", "Assistant","Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminAssistantPatientRole", policy => policy.RequireRole("Admin", "Assistant", "Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminAssistantInsuranceRole", policy => policy.RequireRole("Admin", "Assistant", "Insurance").RequireAuthenticatedUser());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout = new TimeSpan(0, 0, 80);
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

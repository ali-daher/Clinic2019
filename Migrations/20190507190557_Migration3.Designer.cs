﻿// <auto-generated />
using System;
using Clinic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190507190557_Migration3")]
    partial class Migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clinic.Models.Admin", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("admin_fname")
                        .HasMaxLength(50);

                    b.Property<string>("admin_lname")
                        .HasMaxLength(50);

                    b.Property<string>("admin_mname")
                        .HasMaxLength(50);

                    b.HasKey("admin_id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Clinic.Models.Assistant", b =>
                {
                    b.Property<int>("as_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("as_dr_id");

                    b.Property<string>("as_fname")
                        .HasMaxLength(50);

                    b.Property<string>("as_lname")
                        .HasMaxLength(50);

                    b.Property<string>("as_mname")
                        .HasMaxLength(50);

                    b.Property<string>("as_user_id")
                        .IsRequired();

                    b.HasKey("as_id");

                    b.HasIndex("as_dr_id");

                    b.ToTable("Assistants");
                });

            modelBuilder.Entity("Clinic.Models.Consultation", b =>
                {
                    b.Property<int>("cons_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cons_blood_pressure")
                        .HasMaxLength(5);

                    b.Property<int>("cons_cost");

                    b.Property<DateTime>("cons_date");

                    b.Property<string>("cons_diagnosis")
                        .HasMaxLength(500);

                    b.Property<int>("cons_dr_id");

                    b.Property<bool>("cons_insurance_confirmation");

                    b.Property<int>("cons_pat_id");

                    b.Property<string>("cons_symptoms")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("cons_temp")
                        .HasMaxLength(5);

                    b.Property<string>("cons_title")
                        .HasMaxLength(100);

                    b.Property<string>("cons_treatment")
                        .HasMaxLength(500);

                    b.Property<string>("cons_type")
                        .HasMaxLength(50);

                    b.HasKey("cons_id");

                    b.HasIndex("cons_dr_id");

                    b.HasIndex("cons_pat_id");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Clinic.Models.Date", b =>
                {
                    b.Property<int>("date_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date_dateTime");

                    b.Property<int>("date_dr_id");

                    b.Property<int>("date_pat_id");

                    b.HasKey("date_id");

                    b.HasIndex("date_dr_id");

                    b.HasIndex("date_pat_id");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("Clinic.Models.Doctor", b =>
                {
                    b.Property<int>("dr_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dr_about")
                        .HasMaxLength(400);

                    b.Property<string>("dr_address")
                        .HasMaxLength(100);

                    b.Property<string>("dr_fname")
                        .HasMaxLength(50);

                    b.Property<string>("dr_gender")
                        .HasMaxLength(10);

                    b.Property<string>("dr_lname")
                        .HasMaxLength(50);

                    b.Property<string>("dr_mname")
                        .HasMaxLength(50);

                    b.Property<string>("dr_speciality")
                        .HasMaxLength(100);

                    b.Property<string>("dr_user_id")
                        .IsRequired();

                    b.HasKey("dr_id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Clinic.Models.Insurance_company", b =>
                {
                    b.Property<int>("ins_id");

                    b.Property<string>("ins_name")
                        .HasMaxLength(100);

                    b.Property<string>("ins_address")
                        .HasMaxLength(100);

                    b.Property<string>("ins_fax")
                        .HasMaxLength(100);

                    b.Property<string>("ins_user_id")
                        .IsRequired();

                    b.HasKey("ins_id", "ins_name");

                    b.ToTable("Insurance_Companies");
                });

            modelBuilder.Entity("Clinic.Models.Message", b =>
                {
                    b.Property<int>("m_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("m_date");

                    b.Property<string>("m_message")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("m_sender_id")
                        .IsRequired();

                    b.Property<string>("m_subject")
                        .IsRequired();

                    b.HasKey("m_id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Clinic.Models.Patient", b =>
                {
                    b.Property<int>("pat_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("pat_address")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("pat_birthday")
                        .HasColumnType("date");

                    b.Property<string>("pat_blood_type")
                        .HasMaxLength(4);

                    b.Property<string>("pat_fname")
                        .HasMaxLength(50);

                    b.Property<string>("pat_gender")
                        .HasMaxLength(10);

                    b.Property<string>("pat_insurance_company_name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("pat_lname")
                        .HasMaxLength(50);

                    b.Property<string>("pat_mname")
                        .HasMaxLength(50);

                    b.Property<string>("pat_picture")
                        .HasMaxLength(500);

                    b.Property<string>("pat_user_id")
                        .IsRequired();

                    b.HasKey("pat_id");

                    b.HasIndex("pat_insurance_company_name");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Clinic.Models.Reminder_admin", b =>
                {
                    b.Property<int>("reminder_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("reminder_content")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("reminder_date");

                    b.Property<int>("reminder_priority");

                    b.Property<string>("reminder_title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("reminder_id");

                    b.ToTable("Reminder_Admins");
                });

            modelBuilder.Entity("Clinic.Models.Reminder_assistant", b =>
                {
                    b.Property<int>("reminder_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("reminder_content")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("reminder_date");

                    b.Property<int>("reminder_priority");

                    b.Property<string>("reminder_title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("reminder_id");

                    b.ToTable("Reminder_Assistants");
                });

            modelBuilder.Entity("Clinic.Models.Reminder_doctor", b =>
                {
                    b.Property<int>("reminder_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("reminder_content")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("reminder_date");

                    b.Property<int>("reminder_priority");

                    b.Property<string>("reminder_title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("reminder_id");

                    b.ToTable("reminder_Doctors");
                });

            modelBuilder.Entity("Clinic.Models.Reminder_insurance", b =>
                {
                    b.Property<int>("reminder_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("reminder_content")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("reminder_date");

                    b.Property<int>("reminder_priority");

                    b.Property<string>("reminder_title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("reminder_id");

                    b.ToTable("Reminder_Insurances");
                });

            modelBuilder.Entity("Clinic.Models.Reminder_patient", b =>
                {
                    b.Property<int>("reminder_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("reminder_content")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("reminder_date");

                    b.Property<int>("reminder_priority");

                    b.Property<string>("reminder_title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("reminder_id");

                    b.ToTable("reminder_Patients");
                });

            modelBuilder.Entity("Clinic.Models.Report", b =>
                {
                    b.Property<int>("report_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Consultationcons_id");

                    b.Property<int?>("Insurance_companyins_id");

                    b.Property<string>("Insurance_companyins_name");

                    b.Property<int>("report_cons_id");

                    b.Property<string>("report_ins_name")
                        .IsRequired();

                    b.HasKey("report_id");

                    b.HasIndex("Consultationcons_id");

                    b.HasIndex("Insurance_companyins_id", "Insurance_companyins_name");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Assistant",
                            NormalizedName = "ASSISTANT"
                        },
                        new
                        {
                            Id = "4",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        },
                        new
                        {
                            Id = "5",
                            Name = "Insurance_company",
                            NormalizedName = "INSURANCE_COMPANY"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Clinic.Models.Assistant", b =>
                {
                    b.HasOne("Clinic.Models.Doctor", "doctor")
                        .WithMany("Assistants")
                        .HasForeignKey("as_dr_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinic.Models.Consultation", b =>
                {
                    b.HasOne("Clinic.Models.Doctor", "doctor")
                        .WithMany("consultations")
                        .HasForeignKey("cons_dr_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinic.Models.Patient", "patient")
                        .WithMany("consultations")
                        .HasForeignKey("cons_pat_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinic.Models.Date", b =>
                {
                    b.HasOne("Clinic.Models.Doctor", "doctor")
                        .WithMany("dates")
                        .HasForeignKey("date_dr_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinic.Models.Patient", "patient")
                        .WithMany("dates")
                        .HasForeignKey("date_pat_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinic.Models.Patient", b =>
                {
                    b.HasOne("Clinic.Models.Insurance_company", "insurance_company")
                        .WithMany("patients")
                        .HasForeignKey("pat_insurance_company_name")
                        .HasPrincipalKey("ins_name")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinic.Models.Report", b =>
                {
                    b.HasOne("Clinic.Models.Consultation")
                        .WithMany("reports")
                        .HasForeignKey("Consultationcons_id");

                    b.HasOne("Clinic.Models.Insurance_company")
                        .WithMany("reports")
                        .HasForeignKey("Insurance_companyins_id", "Insurance_companyins_name");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

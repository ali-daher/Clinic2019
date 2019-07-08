
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { DoctorRegisterComponent } from './doctor-register/doctor-register.component';
import { InsuranceRegisterComponent } from './insurance-register/insurance-register.component';
import { AssistantRegisterComponent } from './assistant-register/assistant-register.component';

const routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "login", component: LoginComponent },
  { path: "doctor/register", component: DoctorRegisterComponent },
  { path: "insurance/register", component: InsuranceRegisterComponent },
  { path: "assistant/register", component: AssistantRegisterComponent },
  { path: "reset-password", component: ForgetPasswordComponent },
  { path: "**", redirectTo:"/home" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login.component';
import { MessagesComponent } from './messages/messages.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { DoctorRegisterComponent } from './doctor-register/doctor-register.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { InsuranceRegisterComponent } from './insurance-register/insurance-register.component';
import { AssistantRegisterComponent } from './assistant-register/assistant-register.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    MessagesComponent,
    HomeComponent,
    ForgetPasswordComponent,
    DoctorRegisterComponent,
    InsuranceRegisterComponent,
    AssistantRegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ModalModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

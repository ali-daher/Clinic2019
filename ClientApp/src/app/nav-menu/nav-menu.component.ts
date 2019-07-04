import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginService } from '../services/login.service';
import { USE_VALUE } from '@angular/core/src/di/injector';
import { async } from '@angular/core/testing';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  LoginStatus$: Observable<boolean>;

  UserName$: Observable<string>;

  UserRole$: Observable<string>;

  ngOnInit() {
    this.LoginStatus$ = this.loginService.isLoggedIn;
    this.UserName$ = this.loginService.currentUserName;
    this.UserRole$ = this.loginService.currentUserRole;
  }

  onLogout() {
    this.loginService.logout();
  }

  //get isAdmin() {
   // return this.LoginStatus$.pipe(async);// && this.UserRole$
  //}
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AssistantService {

  constructor(private http: HttpClient, private router: Router) { }

  // Url to access our Web API’s
  private baseUrlRegister: string = "/api/assistant/addassistant";

  // Register Method
  register(as_fname: string, as_mname: string, as_lname: string, as_username: string, as_password: string, ConfirmPassword: string,
    as_phone: string, as_email: string, as_dr_name: string) {
    return this.http.post<any>(this.baseUrlRegister, { as_fname, as_mname, as_lname, as_username, as_password, ConfirmPassword, as_phone, as_email, as_dr_name}).pipe(map(result => {
      //registration was successful    
      return result;

    }, error => {
      return error;
    }));
  }
}

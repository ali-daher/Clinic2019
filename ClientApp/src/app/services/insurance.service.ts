import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InsuranceService {

  constructor(private http: HttpClient, private router: Router) { }

  // Url to access our Web API’s
  private baseUrlRegister: string = "/api/insurance/AddInsurance_company";

  // Register Method
  register(ins_name: string, ins_fax: string, ins_username: string, ins_password: string, ConfirmPassword: string,
    ins_phone: string, ins_email: string, ins_address: string) {
    return this.http.post<any>(this.baseUrlRegister, { ins_name, ins_fax, ins_username, ins_password, ConfirmPassword, ins_phone, ins_email, ins_address}).pipe(map(result => {
      //registration was successful
      return result;

    }, error => {
      return error;
    }));
  }
}

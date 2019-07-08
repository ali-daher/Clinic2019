import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map, shareReplay } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Doctor } from '../interfaces/doctor';


@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  constructor(private http: HttpClient, private router: Router) { }

  // Url to access our Web API’s
  private baseUrlRegister: string = "/api/doctors/adddoctor";
  private baseUrlGetAll: string = "/api/doctors/GetDoctorsAsync";
  private Doctors$: Observable<Doctor[]>;
  // Register Method
  register(dr_fname: string, dr_mname: string, dr_lname: string, dr_gender: string, dr_username: string, dr_password: string, ConfirmPassword: string,
    dr_phone: string, dr_speciality: string, dr_email: string, dr_address: string, dr_about: string) {
    return this.http.post<any>(this.baseUrlRegister, { dr_fname, dr_mname, dr_lname, dr_gender, dr_username, dr_password, ConfirmPassword, dr_phone, dr_speciality, dr_email, dr_address, dr_about }).pipe(map(result => {
      //registration was successful
      return result;

    }, error => {
      return error;
    }));
  }

  getAll(): Observable<Doctor[]> {
    if (!this.Doctors$) {
      this.Doctors$ = this.http.get<Doctor[]>(this.baseUrlGetAll).pipe(shareReplay());
    }

    // if companies cache exists return it
    return this.Doctors$;
  }
}

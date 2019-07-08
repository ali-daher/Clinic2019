import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, Validators, AbstractControl, ValidatorFn, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DoctorService } from '../services/doctor.service';
import { Observable } from 'rxjs';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Doctor } from '../interfaces/doctor';
import { AssistantService } from '../assistant.service';

@Component({
  selector: 'app-assistant-register',
  templateUrl: './assistant-register.component.html',
  styleUrls: ['./assistant-register.component.css']
})
export class AssistantRegisterComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private assistantService: AssistantService,
    private DoctorService: DoctorService,
    private router: Router,
    private modalService: BsModalService
  ) { }

  // Properties
  insertForm: FormGroup;
  modalRef: BsModalRef;
  as_username: FormControl;
  as_password: FormControl;
  ConfirmPassword: FormControl;
  as_email: FormControl;
  as_phone: FormControl;
  as_fname: FormControl;
  as_mname: FormControl;
  as_lname: FormControl;
  as_dr_name: FormControl;
  errorList: string[];
  modalMessage: string;
  doctors: Doctor[] = [];
  doctors$: Observable<Doctor[]>;
  phoneRegex = "[+][0-9]{3} [0-9]{8}";
  nameRegex = "^[A-Za-z]+$";
  passRegex = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9_]).*$";

  test: any[] = [];

  @ViewChild('template') modal: TemplateRef<any>;

  onSubmit() {

    let userDetails = this.insertForm.value;

    this.assistantService.register(userDetails.as_fname, userDetails.as_mname, userDetails.as_lname, userDetails.as_username, userDetails.as_password, userDetails.ConfirmPassword,
      userDetails.as_phone, userDetails.as_email, userDetails.as_dr_name).subscribe(result => {

        this.router.navigate(['/home']);
      }, error => {

        this.errorList = [];

        for (var i = 0; i < error.error.value.length; i++) {
          this.errorList.push(error.error.value[i]);
          //console.log(error.error.value[i]);
        }

        console.log(error)
        this.modalMessage = "Your Registration Was Unsuccessful";
        this.modalRef = this.modalService.show(this.modal)
      });
  }

  // Custom Validator

  MustMatch(as_passwordControl: AbstractControl): ValidatorFn {
    return (ConfirmPasswordControl: AbstractControl): { [key: string]: boolean } | null => {
      // return null if controls haven't initialised yet
      if (!as_passwordControl && !ConfirmPasswordControl) {
        return null;
      }

      // return null if another validator has already found an error on the matchingControl
      if (ConfirmPasswordControl.hasError && !as_passwordControl.hasError) {
        return null;
      }
      // set error on matchingControl if validation fails
      if (as_passwordControl.value !== ConfirmPasswordControl.value) {
        return { 'mustMatch': true };
      }
      else {
        return null;
      }

    }
  }

  ngOnInit() {
    this.doctors$ = this.DoctorService.getAll();

    this.doctors$.subscribe(result => {
      this.doctors = result;
    });

    this.as_username = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this.as_password = new FormControl('', [Validators.required, Validators.pattern(this.passRegex), Validators.maxLength(50), Validators.minLength(6)]);
    this.ConfirmPassword = new FormControl('', [Validators.required, this.MustMatch(this.as_password)]);
    this.as_email = new FormControl('', [Validators.required, Validators.email]);
    this.as_phone = new FormControl('', [Validators.required, Validators.pattern(this.phoneRegex)]);
    this.as_fname = new FormControl('', [Validators.required, Validators.pattern(this.nameRegex), Validators.maxLength(50)]);
    this.as_mname = new FormControl('', [Validators.required, Validators.pattern(this.nameRegex), Validators.maxLength(50)]);
    this.as_lname = new FormControl('', [Validators.required, Validators.pattern(this.nameRegex), Validators.maxLength(50)]);
    this.as_dr_name = new FormControl('', [Validators.required, Validators.pattern(this.nameRegex), Validators.maxLength(50)]);
    this.errorList = [];


    this.insertForm = this.fb.group(
      {
        'as_username': this.as_username,
        'as_password': this.as_password,
        'ConfirmPassword': this.ConfirmPassword,
        'as_email': this.as_email,
        'as_phone': this.as_phone,
        'as_fname': this.as_fname,
        'as_mname': this.as_mname,
        'as_lname': this.as_lname,
        'as_dr_name': this.as_dr_name
      });
  }

}

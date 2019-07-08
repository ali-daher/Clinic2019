import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, Validators, AbstractControl, ValidatorFn, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { InsuranceService } from '../services/insurance.service';

@Component({
  selector: 'app-insurance-register',
  templateUrl: './insurance-register.component.html',
  styleUrls: ['./insurance-register.component.css']
})

export class InsuranceRegisterComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private InsuranceService: InsuranceService,
    private router: Router,
    private modalService: BsModalService
  ) { }

  // Properties
  insertForm: FormGroup;
  modalRef: BsModalRef;
  ins_username: FormControl;
  ins_password: FormControl;
  ConfirmPassword: FormControl;
  ins_email: FormControl;
  ins_phone: FormControl;
  ins_name: FormControl;
  ins_fax: FormControl;
  ins_address: FormControl;
  errorList: string[];
  modalMessage: string;
  phoneRegex = "[+][0-9]{3} [0-9]{8}";
  nameRegex = "^[A-Za-z]+$";
  passRegex = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9_]).*$";

  test: any[] = [];

  @ViewChild('template') modal: TemplateRef<any>;

  onSubmit() {

    let userDetails = this.insertForm.value;

    this.InsuranceService.register(userDetails.ins_name, userDetails.ins_fax, userDetails.ins_username, userDetails.ins_password, userDetails.ConfirmPassword,
      userDetails.ins_phone, userDetails.ins_email, userDetails.ins_address).subscribe(result => {

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

  MustMatch(ins_passwordControl: AbstractControl): ValidatorFn {
    return (ConfirmPasswordControl: AbstractControl): { [key: string]: boolean } | null => {
      // return null if controls haven't initialised yet
      if (!ins_passwordControl && !ConfirmPasswordControl) {
        return null;
      }

      // return null if another validator has already found an error on the matchingControl
      if (ConfirmPasswordControl.hasError && !ins_passwordControl.hasError) {
        return null;
      }
      // set error on matchingControl if validation fails
      if (ins_passwordControl.value !== ConfirmPasswordControl.value) {
        return { 'mustMatch': true };
      }
      else {
        return null;
      }

    }
  }

  ngOnInit() {

    
    this.ins_username = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this.ins_password = new FormControl('', [Validators.required, Validators.pattern(this.passRegex), Validators.maxLength(50), Validators.minLength(6)]);
    this.ConfirmPassword = new FormControl('', [Validators.required, this.MustMatch(this.ins_password)]);
    this.ins_email = new FormControl('', [Validators.required, Validators.email]);
    this.ins_phone = new FormControl('', [Validators.required, Validators.pattern(this.phoneRegex)]);
    this.ins_name = new FormControl('', [Validators.required, Validators.pattern(this.nameRegex), Validators.maxLength(50)]);
    this.ins_fax = new FormControl('', [Validators.required, Validators.pattern(this.phoneRegex), Validators.maxLength(50)]);
    this.ins_address = new FormControl('', [Validators.required, Validators.maxLength(100), Validators.minLength(5)]);
    
    this.errorList = [];

    this.insertForm = this.fb.group(
      {
        'ins_username': this.ins_username,
        'ins_password': this.ins_password,
        'ConfirmPassword': this.ConfirmPassword,
        'ins_email': this.ins_email,
        'ins_phone': this.ins_phone,
        'ins_name': this.ins_name,
        'ins_fax': this.ins_fax,
        'ins_address': this.ins_address,
      });
  }

}

import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {
  logInError: string;
  userForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });


  constructor(private router: Router, private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }
  
  logIn() {
    const userFormFields = this.userForm.value;
    if (userFormFields.username && userFormFields.password)
    {
      this.authenticationService.login(userFormFields.username, userFormFields.password)
      .subscribe(
        success => {
          const nextUrl = this.authenticationService.isAdmin() ? '/admin' : '';
          this.router.navigate([nextUrl]);
        },
        error => {
          this.logInError = "User does not exist!";
        });   
    }
    if (!userFormFields.password){
      this.logInError = "Password is required";
    }
    if (!userFormFields.username){
      this.logInError = "Username is required";
    }
  }
}

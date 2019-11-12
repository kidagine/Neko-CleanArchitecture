import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { FormGroup, FormControl } from '@angular/forms';
import { User } from '../models/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  user: any;
  registerError: string;
  userForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    repeatPassword: new FormControl('')
  });

  constructor(private router: Router, private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }

  register() {
    const userFormFields = this.userForm.value;
    if (userFormFields.username && userFormFields.password)
    {
      if (userFormFields.password === userFormFields.repeatPassword)
      {
        // this.user =this.authenticationService.newUser(userFormFields.username, userFormFields.password).subscribe(
          // this.authenticationService.addUser(this.user).subscribe();
        // )
      }
      else{
        this.registerError = "Passwords do not match!";
      }
    }
    if (!userFormFields.password){
      this.registerError = "Password is required";
    }
    if (!userFormFields.username){
      this.registerError = "Username is required";
    }
  }

}

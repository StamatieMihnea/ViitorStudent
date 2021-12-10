import { LoginModel } from './../../models/login.model';
import { LoginService } from './../../services/login.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
})
export class LoginFormComponent implements OnInit {
  constructor(private loginService: LoginService) {}
  loginModel: LoginModel = new LoginModel();
  ngOnInit(): void {}

  loginUser(): void {
    this.loginService.loginUser(this.loginModel).subscribe((data) => {
      localStorage.setItem('jwt', data.token);
      console.log(data);
    });
  }
}

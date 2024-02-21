import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,ReactiveFormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  passwordType:string = 'password';
  private _passType:string = 'password';
  private _textType:string = 'text';

  loginForm = this.fb.group({
    email:['',[Validators.required,Validators.email]],
    password:['',Validators.required],
    rememberMe:''
  })
  isSubmitted=false;
  constructor(private fb:FormBuilder){}

  togglePassword(){
    this.passwordType === this._passType 
    ? (this.passwordType = this._textType)
    : (this.passwordType = this._passType);
  }

  onSubmit():void{
    console.log('Submited form ',this.loginForm.value);
    
  }
}

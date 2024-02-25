import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { UserDataService } from '../services/user-data.service';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { AnimateModule } from 'primeng/animate';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,ReactiveFormsModule,CommonModule,ToastModule,AnimateModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers:[MessageService]
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
  constructor(private fb:FormBuilder,private UserService:UserDataService,private router:Router,private messageService:MessageService,private toastr: ToastrService){}

  togglePassword(){
    this.passwordType === this._passType 
    ? (this.passwordType = this._textType)
    : (this.passwordType = this._passType);
  }

  onSubmit():void{
    // console.log('Submited form ',this.loginForm.value);
  }

  onLogin(){
    const email = this.loginForm.value.email;
    const password = this.loginForm.value.password;

    this.UserService.login(email!, password!).subscribe(
      (result) => {
        // Check if result is successful
        if (result ) {
          console.log(result);
          localStorage.setItem("token", result.token);
          
          // Navigate only after successful login
          this.router.navigateByUrl('/jobs');
  
          // Display success message
          // this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Login Successful' });
          this.toastr.success('Login Successful');
        } else {
          // Handle other cases, e.g., invalid credentials
          // You can display error message or handle it as per your application's requirement
          console.log("Login failed:", result);
          // Display error message
          // this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Login Failed' });
          this.toastr.error('Login Failed');
        }
      },
      (error) => {
        // Handle error scenario
        console.error("Error occurred:", error);
        // Display error message
        // this.messageService.add({ severity: 'error', summary: 'Error', detail: 'An error occurred while logging in' });
        this.toastr.error('An error occurred while logging in');
      }
    );
  }

  showSuccess(){
    // this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Login Successful' });
    // this.toastr.success('Hello world!', 'Toastr fun!');
  }
}

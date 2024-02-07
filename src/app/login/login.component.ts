import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  passwordType:string = 'password';
  private _passType:string = 'password';
  private _textType:string = 'text';

  togglePassword(){
    this.passwordType === this._passType 
    ? (this.passwordType = this._textType)
    : (this.passwordType = this._passType);
  }
}

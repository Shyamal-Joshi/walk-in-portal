import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  constructor(private http:HttpClient) { }

  _baseUrl:string="http://localhost:5107/api/";

  login(email:string , password:string){
    return this.http.post<{token:string}>(this._baseUrl+'Auth/login',{
      email:email,
      password:password
    })
  }
}

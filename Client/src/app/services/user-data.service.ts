import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUserRegistration } from '../interface';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  constructor(private http:HttpClient) { }

  _baseUrl:string="http://localhost:5107/api/";

  login(email:string , password:string){
    return this.http.post<{token:string,userId:string}>(this._baseUrl+'Auth/login',{
      email:email,
      password:password
    })
  }

  headers = new HttpHeaders({
    'Content-Type': 'application/json'
  });
  register(registerBody:any){
    console.log(registerBody);
    
    return this.http.post<{message:string}>(this._baseUrl+'v1/register',registerBody)
  }

  getJobRoleNames():Observable<string[]>{
    return this.http.get<string[]>(this._baseUrl+'v1/getJobRoles');
  }

  getQualification():Observable<string[]>{
    return this.http.get<string[]>(this._baseUrl+'v1/getQualifications');
  }

  getColleges():Observable<string[]>{
    return this.http.get<string[]>(this._baseUrl+'v1/getColleges');
  }

  getStreams():Observable<string[]>{
    return this.http.get<string[]>(this._baseUrl+'v1/getStreams');
  }

  getTechnologies():Observable<string[]>{
    return this.http.get<string[]>(this._baseUrl+'v1/getTechnologies');
  }

}

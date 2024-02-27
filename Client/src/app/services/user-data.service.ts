import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

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

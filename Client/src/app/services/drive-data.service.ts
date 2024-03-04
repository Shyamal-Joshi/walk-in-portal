import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IDetailDrive, IDrivesdata, userApplication } from '../interface';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DriveDataService {

  constructor(private http:HttpClient) { }

  _baseUrl:string="http://localhost:5107/api/v1/";

  getAllDriveData(): Observable<IDrivesdata[]>{
    return this.http.get<IDrivesdata[]>(this._baseUrl+'getAllDrives');
  }

  getDriveById(id:number):Observable<IDetailDrive[]>{
    return this.http.get<IDetailDrive[]>(this._baseUrl+`getDrive/${id}`);
  }

  applyJob(jobApplication:any){
    return this.http.post(this._baseUrl+'applyJob',jobApplication);
  }
}

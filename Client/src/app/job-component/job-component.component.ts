import { Component, OnInit } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { ActivatedRoute } from '@angular/router';
import { IDetailDrive } from '../interface';
import { DriveDataService } from '../services/drive-data.service';
import { TransformTimePipe } from '../Pipes/transform-time.pipe';
import { TransformDatePipe } from '../Pipes/trasform-date.pipe';


@Component({
  selector: 'app-job-component',
  standalone: true,
  imports: [MatIcon,TransformTimePipe,TransformDatePipe],
  templateUrl: './job-component.component.html',
  styleUrl: './job-component.component.scss'
})
export class JobComponentComponent implements OnInit{
  public isPreRequisitesOpen=false;

  public DriveDetails : IDetailDrive[] = [];

  isJobRolesOpen: boolean[] = [];
  private _jobid:any;
  constructor(private route:ActivatedRoute,private _dataService:DriveDataService){}
  ngOnInit(): void {
    let id:number | null = +this.route.snapshot.paramMap.get('id')!;
    this._jobid=id;

    this._dataService.getDriveById(this._jobid)
    .subscribe((data:any) =>{
      this.DriveDetails = data
    });

    console.log(this.DriveDetails);

  }

  tooglePreRequisitesOpen(){
    this.isPreRequisitesOpen=!this.isPreRequisitesOpen;
  }

  toogleisJobRolesOpen(id:any){
    this.isJobRolesOpen[id]=!this.isJobRolesOpen[id];
  }

}

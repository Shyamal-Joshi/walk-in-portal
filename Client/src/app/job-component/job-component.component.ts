import { Component, OnInit } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { ActivatedRoute } from '@angular/router';
import { IDetailDrive, userApplication } from '../interface';
import { DriveDataService } from '../services/drive-data.service';
import { TransformTimePipe } from '../Pipes/transform-time.pipe';
import { TransformDatePipe } from '../Pipes/trasform-date.pipe';
import { FormArray, FormControl, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';


@Component({
  selector: 'app-job-component',
  standalone: true,
  imports: [MatIcon,TransformTimePipe,TransformDatePipe,ReactiveFormsModule,ToastModule],
  templateUrl: './job-component.component.html',
  styleUrl: './job-component.component.scss',
  providers:[MessageService]
})
export class JobComponentComponent implements OnInit{


  public isPreRequisitesOpen=false;

  public DriveDetails : IDetailDrive[] = [];

  isJobRolesOpen: boolean[] = [];
  private _jobid:any;

  userAppliedJob = new FormGroup({
    timeSlot:new FormControl('',[Validators.required]),
    resumePath:new FormControl('',[Validators.required]),
    preferredJobRoles:new FormArray([],[Validators.required]),
  })

  apply(){
    console.log(this.userAppliedJob.value);
    var jobApplication = {
      JobId:this._jobid,
      JobRoles:this.userAppliedJob.get('preferredJobRoles')!.value,
      TimeSlot:this.userAppliedJob.get('timeSlot')!.value,
      UserId:localStorage.getItem("userId"),
      UserResume:this.userAppliedJob.get('resumePath')!.value
    }
    this._dataService.applyJob(jobApplication).subscribe();

  }
  constructor(private route:ActivatedRoute,private _dataService:DriveDataService,private messageService:MessageService){}
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

  onChange(e:any){
    const selectedValue=e.target.value;
    const checked=e.target.checked;

    const jobRoleArray = this.userAppliedJob.get('preferredJobRoles') as FormArray;

    if(checked){
      jobRoleArray.push(new FormControl(selectedValue));
    }
    else{
      let i:number=0;
      jobRoleArray.controls.forEach((item)=>{
        if(item.value==selectedValue){
          jobRoleArray.removeAt(i);
        }
      })
    }
  }

  onCheck(){
    // this.parentComponent.moveToNextStep() 
    if(this.userAppliedJob.valid){
      
    }
    else{
      Object.keys(this.userAppliedJob.controls).forEach(key => {
        const controlErrors: any = this.userAppliedJob.get(key)?.errors;
        if (controlErrors != null) {
          Object.keys(controlErrors).forEach(keyError => {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: key + ', Error: ' + keyError,sticky: true});
          });
        }
      });
    }
  }

}

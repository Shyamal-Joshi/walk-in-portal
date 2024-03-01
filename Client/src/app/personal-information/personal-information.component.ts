import { CommonModule } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';
import { FormArray, FormControl, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserDataService } from '../services/user-data.service';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { AnimateModule } from 'primeng/animate';

@Component({
  selector: 'app-personal-information',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule,ToastModule ],
  templateUrl: './personal-information.component.html',
  styleUrl: './personal-information.component.scss',
  providers:[UserDataService,MessageService]
})
export class PersonalInformationComponent implements OnInit {
  @Input() parentComponent!: any;
  isSubmitted = false;
  
  personalInfoForm:FormGroup;

  RoleNames : string[] =[];

  constructor(private rootFormGroup: FormGroupDirective,private userService:UserDataService,private messageService:MessageService) {
    this.personalInfoForm = {} as FormGroup;
  }
  ngOnInit(): void {
    this.personalInfoForm = this.rootFormGroup.control;

    this.userService.getJobRoleNames()
    .subscribe((data:string[])=>{
      this.RoleNames=data;
    });
  }

  onSubmit(){
    console.log(this.personalInfoForm.value);
    this.isSubmitted=true;
  }

  onChange(e:any){
    const selectedValue=e.target.value;
    const checked=e.target.checked;

    const jobRoleArray = this.personalInfoForm.get('preferredJobRoles') as FormArray;

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
    if(this.personalInfoForm.valid){
      this.parentComponent.moveToNextStep()      
    }
    else{
      console.log(this.personalInfoForm.getError('firstName'));
      Object.keys(this.personalInfoForm.controls).forEach(key => {
        const controlErrors: any = this.personalInfoForm.get(key)?.errors;
        if (controlErrors != null) {
          Object.keys(controlErrors).forEach(keyError => {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: key + ', Error: ' + keyError,sticky: true});
          });
        }
      });
    }
  }
  
}

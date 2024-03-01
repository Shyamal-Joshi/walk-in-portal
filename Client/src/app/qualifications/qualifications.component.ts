import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

import { MatIconModule } from '@angular/material/icon';
import { UserDataService } from '../services/user-data.service';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { AnimateModule } from 'primeng/animate';
import { __values } from 'tslib';

@Component({
  selector: 'app-qualifications',
  standalone: true,
  imports: [MatIconModule,CommonModule,FormsModule,ReactiveFormsModule,ToastModule],
  templateUrl: './qualifications.component.html',
  styleUrl: './qualifications.component.scss',
  providers:[UserDataService,MessageService]
})
export class QualificationsComponent implements OnInit {
  isEducationalQualificationVisible:boolean = false;
  isProfessionalQualificationVisible:boolean = false;
  
  isOnNoticePeriod:boolean = false;

  //array for dropdown values
  qualificationArray:string[]=[];
  streamArray:string[]=[];
  collegeArray:string[]=[];
  technologiesArray:string[]=[];

  @Input() parentComponent!:any;
  @Input() EducationQualificationForm!:FormGroup;
  @Input() ProfessionalQualificationForm!:FormGroup;


  constructor(private userService:UserDataService,private messageService:MessageService){
    
    //   this.parentComponent.professionalQualification.get('applicationType')!.valueChanges.subscribe((value:string)=>{
    //   if(value=== 'fresher'){
    //     console.log(value);
    //     var exp=this.parentComponent.professionalQualification.get('yearsOfExperience')!;
    //     // console.log(exp.value);
        
    //     exp.setValidators(null);
    //     this.parentComponent.professionalQualification.get('currentCtc')?.setValidators(null);
    //     this.parentComponent.professionalQualification.get('expectedCtc')?.setValidators(null);
    //     this.parentComponent.professionalQualification.get('expertiseTechnology')?.setValidators(null);
    //     this.parentComponent.professionalQualification.get('noticePeriod')?.setValidators(null);
    //     this.parentComponent.professionalQualification.updateValueAndValidity();

    //   }
    //   else{
    //     var exp=this.parentComponent.professionalQualification.get('yearsOfExperience')!;
    //     console.log(exp.value);
    //     this.parentComponent.professionalQualification.get('yearsOfExperience')?.setValidators([Validators.required]);
    //     this.parentComponent.professionalQualification.get('currentCtc')?.setValidators([Validators.required]);
    //     this.parentComponent.professionalQualification.get('expectedCtc')?.setValidators([Validators.required]);
    //     this.parentComponent.professionalQualification.get('expertiseTechnology')?.setValidators([Validators.required]);
    //     this.parentComponent.professionalQualification.get('noticePeriod')?.setValidators([Validators.required]);
    //     this.parentComponent.professionalQualification.updateValueAndValidity();

    //   }
    // })
    
  }
  ngOnInit(): void {
    this.userService.getColleges().subscribe((data:string[])=>{
      this.collegeArray=data;
    });
    this.userService.getQualification().subscribe((data:string[])=>{
      this.qualificationArray=data;
    });
    this.userService.getStreams().subscribe((data:string[])=>{
      this.streamArray=data;
    });
    this.userService.getTechnologies().subscribe((data:string[])=>{
      this.technologiesArray=data;
    });


  }
  toogleEducationalQualification(){
    this.isEducationalQualificationVisible = !this.isEducationalQualificationVisible;
  }
  toogleProfessionalQualification(){
    this.isProfessionalQualificationVisible = !this.isProfessionalQualificationVisible;
  }

  onSubmit(){
    this.parentComponent.moveToNextStep();
    // console.log(this.EducationQualificationForm.value);
    
    // console.log(this.ProfessionalQualificationForm.value);
  }

  onApplicationTypeChange(){
    
    var value =this.parentComponent.professionalQualification.get('applicationType').value;
      if(value=== 'fresher'){
        console.log(value);
        var exp=this.parentComponent.professionalQualification.get('yearsOfExperience')!;
        // console.log(exp.value);
        
        exp.setValidators(null);
        this.parentComponent.professionalQualification.get('currentCtc')?.clearValidators();
        this.parentComponent.professionalQualification.get('currentCtc').updateValueAndValidity();
        this.parentComponent.professionalQualification.get('expectedCtc')?.clearValidators();
        this.parentComponent.professionalQualification.get('expectedCtc').updateValueAndValidity();
        
        this.parentComponent.professionalQualification.get('expertiseTechnology')?.clearValidators();
        this.parentComponent.professionalQualification.get('expertiseTechnology').updateValueAndValidity();
        
        this.parentComponent.professionalQualification.get('noticePeriod')?.clearValidators();
        this.parentComponent.professionalQualification.get('noticePeriod').updateValueAndValidity();
        
        

      }
      else{
        var exp=this.parentComponent.professionalQualification.get('yearsOfExperience')!;
        console.log(exp.value);
        this.parentComponent.professionalQualification.get('yearsOfExperience')?.setValidators([Validators.required]);
        this.parentComponent.professionalQualification.get('currentCtc')?.setValidators([Validators.required]);
        this.parentComponent.professionalQualification.get('expectedCtc')?.setValidators([Validators.required]);
        this.parentComponent.professionalQualification.get('expertiseTechnology')?.setValidators([Validators.required]);
        this.parentComponent.professionalQualification.get('noticePeriod')?.setValidators([Validators.required]);
      }
    
    console.log("Hello from app type");

  }

  onNoticePeriodChange(){
    
      const value = this.parentComponent.professionalQualification.get('noticePeriod')?.value;
      console.log(value);
      
      if(value){
        this.parentComponent.professionalQualification.get('noticePeriodDuration')?.setValidators([Validators.required]);
        this.parentComponent.professionalQualification.get('noticePeriodDuration').updateValueAndValidity();
        this.parentComponent.professionalQualification.get('noticePeriodDate')?.setValidators([Validators.required]);
        this.parentComponent.professionalQualification.get('noticePeriodDate').updateValueAndValidity();
        
      }
      else{
        this.parentComponent.professionalQualification.get('noticePeriodDuration')?.clearValidators();
        this.parentComponent.professionalQualification.get('noticePeriodDuration')?.updateValueAndValidity();
        this.parentComponent.professionalQualification.get('noticePeriodDate')?.clearValidators();
        this.parentComponent.professionalQualification.get('noticePeriodDate')?.updateValueAndValidity();
        // this.ProfessionalQualificationForm.updateValueAndValidity();

      }
      
    

    
  }

  onChange(e:any,field:string){
    const selectedValue=e.target.value;
    const checked=e.target.checked;

    const tempArray = this.ProfessionalQualificationForm.get(field) as FormArray;

    if(checked){
      tempArray.push(new FormControl(selectedValue));
    }
    else{
      let i:number=0;
      tempArray.controls.forEach((item:any)=>{
        if(item.value==selectedValue){
          tempArray.removeAt(i);
        }
      })
    }
  }


  onCheck(){
    // this.parentComponent.moveToNextStep() 
    if(this.EducationQualificationForm.valid && this.ProfessionalQualificationForm.valid){
      this.parentComponent.moveToNextStep()      
    }
    else{
      Object.keys(this.EducationQualificationForm.controls).forEach(key => {
        
        
        const controlErrors: any = this.EducationQualificationForm.get(key)?.errors;
        if (controlErrors != null) {
          Object.keys(controlErrors).forEach(keyError => {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: key + ', Error: ' + keyError,sticky: true});
          });
        }
      });
      Object.keys(this.ProfessionalQualificationForm.controls).forEach(key => {
        // console.log(key)
        const controlErrors: any = this.ProfessionalQualificationForm.get(key)?.errors;
        if (controlErrors != null) {
          Object.keys(controlErrors).forEach(keyError => {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: key + ', Error: ' + keyError,sticky: true});
          });
        }
      });
    }
  }
}

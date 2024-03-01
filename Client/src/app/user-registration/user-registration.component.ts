import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { PersonalInformationComponent } from '../personal-information/personal-information.component';
import { QualificationsComponent } from '../qualifications/qualifications.component';
import { PreviewProfileComponent } from '../preview-profile/preview-profile.component';
import { FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule,Validators  } from '@angular/forms';
import { IUserRegistration } from '../interface';
import { UserDataService } from '../services/user-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-registration',
  standalone: true,
  imports: [
    MatIconModule,
    CommonModule,
    PersonalInformationComponent,
    QualificationsComponent,
    PreviewProfileComponent,
    ReactiveFormsModule,
  ],
  templateUrl: './user-registration.component.html',
  styleUrl: './user-registration.component.scss',
})
export class UserRegistrationComponent {
  isDisable: boolean = true;
  currentStep: number = 1;
  registerBody:any={
    personalInfo : {},
    eduQualification :{},
    profQualification : {}
  }
  constructor(private UserService:UserDataService,private router:Router){}
  personalInformation=new FormGroup({
    firstName:new FormControl('',[Validators.required]),
    lastName:new FormControl('',[Validators.required]),
    email:new FormControl('',[Validators.required,Validators.email]),
    phoneNumber:new FormControl('',[Validators.required,Validators.minLength(10)]),
    resumePath:new FormControl('',[Validators.required]),
    portfolioUrl:new FormControl(''),
    profilePhotoUrl:new FormControl(''),
    preferredJobRoles:new FormArray([],[Validators.required]),
    referralName:new FormControl(''),
    newsletter:new FormControl(false),
  });

  EducationalQualification= new FormGroup({
    aggregatedPercentage:new FormControl('',[Validators.required]),
    yearOfPassing:new FormControl('2021',[Validators.required]),
    qualification:new FormControl('',[Validators.required]),
    stream:new FormControl('',[Validators.required]),
    college:new FormControl('',[Validators.required]),
    otherCollege:new FormControl(''),
    collegeLocation:new FormControl('',[Validators.required]),
  });

  // professionalQualification = new FormGroup({
  //   applicationType: new FormControl('fresher', [Validators.required]),
  //   familiarTechnologies: new FormArray([]),
  //   otherFamiliarTechnologies: new FormControl(''),
  //   previouslyApplied: new FormControl(false),
  //   previouslyAppliedRole: new FormControl(''),
  //   yearsOfExperience: new FormControl(0, [Validators.required]),
  //   currentCtc: new FormControl('', [Validators.required]),
  //   expectedCtc: new FormControl('', [Validators.required]),
  //   expertiseTechnology: new FormArray([], [Validators.required]),
  //   otherExpertiseTechnology: new FormControl(''),
  //   noticePeriod: new FormControl(false, [Validators.required]),
  //   noticePeriodDuration: new FormControl(0),
  //   noticePeriodDate: new FormControl(''),
  // });

  professionalQualification = new FormGroup({
    applicationType: new FormControl('fresher', [Validators.required]),
    familiarTechnologies: new FormArray([]),
    otherFamiliarTechnologies: new FormControl(''),
    previouslyApplied: new FormControl(false),
    previouslyAppliedRole: new FormControl(''),
    yearsOfExperience: new FormControl(0),
    currentCtc: new FormControl(0),
    expectedCtc: new FormControl(0),
    expertiseTechnology: new FormArray([]),
    otherExpertiseTechnology: new FormControl(''),
    noticePeriod: new FormControl(false),
    noticePeriodDuration: new FormControl(0),
    noticePeriodDate: new FormControl(new Date()),
  });

  

  onCreate(){
    this.registerBody = {
      personalInfo : this.personalInformation.value,
      eduQualification : this.EducationalQualification.value,
      profQualification : this.professionalQualification.value
    }
    console.log(this.registerBody);
    // console.log(this.personalInformation.value);
    // console.log(this.EducationalQualification.value);
    // console.log(this.professionalQualification.value);
    
    this.UserService.register(this.registerBody).subscribe({
      next: response => {
        console.log('Response:', response);
      },
      error: error => {
        console.error('Error:', error);
      }
    });
    
  }

  moveToNextStep():void {
    this.currentStep++;
    if (this.currentStep === 3) this.isDisable = false;
  }

  moveToPreviousStep() {
    this.currentStep--;
  }

  idCompletedThisStep(step: number): boolean {
    if (this.currentStep >= step) return true;
    else return false;
  }

  onTesting(){
    console.log(this.personalInformation.value);
    console.log(this.EducationalQualification.value);
    
  }
}

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { PersonalInformationComponent } from '../personal-information/personal-information.component';
import { QualificationsComponent } from '../qualifications/qualifications.component';
import { PreviewProfileComponent } from '../preview-profile/preview-profile.component';
import { FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule,Validators  } from '@angular/forms';

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

  personalInformation=new FormGroup({
    firstName:new FormControl('',[Validators.required]),
    lastName:new FormControl('',[Validators.required]),
    email:new FormControl('',[Validators.required,Validators.email]),
    phoneNumber:new FormControl('',[Validators.required,Validators.minLength(10)]),
    resumePath:new FormControl('',[Validators.required]),
    portfolioUrl:new FormControl(''),
    preferredJobRoles:new FormArray([],[Validators.required]),
    referralName:new FormControl(''),
    newsletter:new FormControl(false),
  });

  moveToNextStep():void {
    console.log(this.currentStep);
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
    
  }
}

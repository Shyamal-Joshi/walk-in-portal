import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-qualifications',
  standalone: true,
  imports: [MatIconModule,CommonModule,FormsModule],
  templateUrl: './qualifications.component.html',
  styleUrl: './qualifications.component.scss'
})
export class QualificationsComponent  {
  isEducationalQualificationVisible:boolean = false;
  isProfessionalQualificationVisible:boolean = false;
  isExperienced:boolean = false;

  
  toogleEducationalQualification(){
    this.isEducationalQualificationVisible = !this.isEducationalQualificationVisible;
  }
  toogleProfessionalQualification(){
    this.isProfessionalQualificationVisible = !this.isProfessionalQualificationVisible;
  }

  
}

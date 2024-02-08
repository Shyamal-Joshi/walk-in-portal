import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { PersonalInformationComponent } from '../personal-information/personal-information.component';
import { QualificationsComponent } from '../qualifications/qualifications.component';

@Component({
  selector: 'app-user-registration',
  standalone: true,
  imports: [MatIconModule,CommonModule,PersonalInformationComponent,QualificationsComponent],
  templateUrl: './user-registration.component.html',
  styleUrl: './user-registration.component.scss'
})
export class UserRegistrationComponent {
  isDisable:boolean=true;
}

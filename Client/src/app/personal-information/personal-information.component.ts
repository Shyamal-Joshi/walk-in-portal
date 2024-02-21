import { CommonModule } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';
import { FormArray, FormControl, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-personal-information',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule],
  templateUrl: './personal-information.component.html',
  styleUrl: './personal-information.component.scss',
})
export class PersonalInformationComponent implements OnInit {
  @Input() parentComponent!: any;
  isSubmitted = false;
  
  personalInfoForm:FormGroup;

  constructor(private rootFormGroup: FormGroupDirective) {
    this.personalInfoForm = {} as FormGroup;
  }
  ngOnInit(): void {
    this.personalInfoForm = this.rootFormGroup.control;
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
 
}

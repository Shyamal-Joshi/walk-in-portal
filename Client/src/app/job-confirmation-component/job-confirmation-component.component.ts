import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TransformDatePipe } from '../Pipes/trasform-date.pipe';
import { TransformTimePipe } from '../Pipes/transform-time.pipe';

@Component({
  selector: 'app-job-confirmation-component',
  standalone: true,
  imports: [TransformDatePipe,TransformTimePipe],
  templateUrl: './job-confirmation-component.component.html',
  styleUrl: './job-confirmation-component.component.scss'
})
export class JobConfirmationComponentComponent {

  stateData:any;
  timeArr:string[]=[];
  print(){
    window.print();
  }

  constructor(private router:Router){
    console.log(this.router.getCurrentNavigation()!.extras.state);
    this.stateData=this.router.getCurrentNavigation()!.extras.state;
    this.timeArr=this.stateData.timeSlot.split('-');
  }
}

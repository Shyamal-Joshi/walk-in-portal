import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { IDrivesdata } from '../interface';
import { DriveDataService } from '../services/drive-data.service';
import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { TransformDatePipe } from '../Pipes/trasform-date.pipe';

@Component({
  selector: 'app-job-listing',
  standalone: true,
  imports: [MatIconModule,RouterLink,HttpClientModule,TransformDatePipe],
  templateUrl: './job-listing.component.html',
  styleUrl: './job-listing.component.scss',
  providers:[DriveDataService,DatePipe]
})
export class JobListingComponent implements OnInit{
  
  public Jobs : IDrivesdata[]  = [];

  constructor(private _dataService:DriveDataService , private datePipe:DatePipe){}
  ngOnInit(): void {
    this._dataService.getAllDriveData()
    .subscribe((data:any) => {
      this.Jobs = data;
    })
  }
  CalculateTimeDiffrence(start_date:Date , end_date:Date){
    const startDate=new Date(start_date);
    const endDate=new Date(end_date);
    return (endDate.getTime() - startDate.getTime()) / (1000*3600*24)
  }
}

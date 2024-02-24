import { Component, OnInit } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { ActivatedRoute } from '@angular/router';
import { IDetailDrive } from '../interface';
import { DriveDataService } from '../services/drive-data.service';
import { TransformTimePipe } from '../Pipes/transform-time.pipe';
import { TransformDatePipe } from '../Pipes/trasform-date.pipe';


@Component({
  selector: 'app-job-component',
  standalone: true,
  imports: [MatIcon,TransformTimePipe,TransformDatePipe],
  templateUrl: './job-component.component.html',
  styleUrl: './job-component.component.scss'
})
export class JobComponentComponent implements OnInit{
  public isPreRequisitesOpen=false;

  public DriveDetails : IDetailDrive[] = [];

  isJobRolesOpen: boolean[] = [];
  private _jobid:any;
//   public jobs=[
//     {
//         "id": 1,
//         "title": "Walk In for Designer Job Role",
//         "startDate": "10-Jul-2021",
//         "endDate": "11-Jul-2021",
//         "location": "Mumbai",
//         "isExpiring": true,
//         "isExpiringTitle": "Expires in 5 days",
//         "isExtraRoles": false,
//         "isExtraRolesTitle": "",
//         "timeSlots": [
//             "9:00 AM to 11:00 AM",
//             "1:00 PM to 3:00 PM"
//         ],

//         "jobRoleWithDetails":[
//           {
//             "package":500000,

//             "job_role":"Instructional Designer",

//             "roleDescription":"- Generate highly interactive and innovative instructional strategies for e-learning solutions - Develop course structure and learning specifications addressing the requirements of the target audience - Construct appropriate testing strategies to ensure learners' understanding and performance - Address usability issues - Keep abreast of new trends in e-learning - Ensure that the instructional strategies are as per global standards - Prepare instructional design checklists and guidelines - Check for quality assurance",

//             "requirements":"- Experience in creating instructional plans and course maps. - Experience in the use of media like graphics, illustrations, photographs, audio, video, animations, and simulations in instruction - Awareness of different instructional design models and familiarity with instructional and learning theories - Awareness of latest trends in e-learning and instructional design - Strong client consulting/interfacing skills. - Ability to guide clients to focus on specific objectives and teaching points - Strong meeting facilitation, presentation and interpersonal skills - A thorough understanding of the web as an instructional medium - Post graduate degree in Education, Instructional Design, Mass Communication or Journalism",
//           }
//         ],
//         "generalInstructions": "- We have a two-year indemnity for permanent candidates. We will provide training to the selected candidates. - Candidates who have appeared for any test held by Zeus Learning in the past 12 months will not be allowed to appear for this recruitment test.",

//         "instructionsForTheExam": "- Candidates are requested to log in half an hour prior to the exam start time as they would need to capture their image using a web camera. By taking this test, you are permitting the examination system to capture your video for invigilation purposes. - Candidates would not be able to appear for the exam if the web camera attached to their system is not functional. - The web camera of your system must be enabled and must remain switched on throughout the examination. In the event of non-receipt of a webcam, your examination will be considered null and void. - Candidate's audio and video will be recorded during the examination and will also be monitored by a live proctor. The proctor may terminate your exam in case he/she observes any malpractice during the exam. - Candidates are advised to use their own Laptop/PC with a stable internet connection (min 1 Mbps) during the exam. - Candidates cannot use an iOS system/device for this exam.",

//         "minimumSystemRequirements": "- Personal Laptop or Desktop computer in working condition with good quality camera (you can use Windows 7 and above). - The latest version of Google Chrome Browser only. - Please note that Internet speed should be minimum 1 Mbps. - Do not use a MacBook or iPad for the proctored exam.",

//         "process": "- Every round is an elimination round. Candidates need to clear all rounds to get selected. Round I : 4th August, 2018 Aptitude Test : 25 Questions Round II (Interview) : 4th August, 2018.",

//         "address": {
//             "name": "Zeus Systems Pvt. Ltd.",
//             "addressLine1": "1402, 14th Floor, Tower B, Peninsula Business Park. Ganpatrao Kadam Marg",
//             "area": "Lower Parel (W)",
//             "city": "Mumbai",
//             "pincode": "400 013",
//             "phone": "91-22-66600000"
//         },

//         "thingsToRemember": "- Please report 30 MINUTES prior to your reporting time. - Download your Hall Ticket from below and carry it with you during your Walk-In."
//     },
// ]

  constructor(private route:ActivatedRoute,private _dataService:DriveDataService){}
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

}

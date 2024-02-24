import { Time } from "@angular/common"

export interface IDrivesdata{
    application_id : number,
    job_role: string[],
    application:IApplication,
}

export interface IDetailDrive{
    application_id : number,
    application:IApplication,
    jobRoleWithDetails:IJobDetails[],
    time_slot:ITimeSlot
}

export interface IApplication{
    title:string,
    location:string,
    additionalInformation:string | null,
    general_instruction:string | null,
    exam_instruction:string | null,
    systemRequirements:string | null,
    application_process:string | null,
    start_date:Date,
    end_date:Date,
}

export interface IJobDetails{
    job_role:string,
    requirements:string,
    roleDescription:string,
    package:string,
}

export interface ITimeSlot{
    timestamp: [
        {
            start_time:string,
            end_time:string,
        }
    ]
}
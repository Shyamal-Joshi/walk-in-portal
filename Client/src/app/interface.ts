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

export interface IPersonalInformation{
    firstName:string,
    lastName:string,
    email:string,
    phoneNumber:string,
    resumePath:string,
    portfolioUrl:string,
    profilePhotoUrl:string,
    preferredJobRoles:string[],
    referralName:string,
    newsletter:boolean,
}

export interface IEducationalQualification{
    aggregatedPercentage:string,
    yearOfPassing:string,
    qualification:string,
    stream:string,
    college:string,
    otherCollege:string,
    collegeLocation:string,
}

export interface IProfessionalQualification{
    applicationType: string,
    familiarTechnologies: string[],
    otherFamiliarTechnologies: string,
    previouslyApplied: boolean,
    previouslyAppliedRole: string,
    yearsOfExperience: number,
    currentCtc: number,
    expectedCtc: number
    expertiseTechnology: string[],
    otherExpertiseTechnology: string,
    noticePeriod: boolean
    noticePeriodDuration: number,
    noticePeriodDate: Date,
}

export interface IUserRegistration{
    personalInfo:IPersonalInformation,
    eduQualification:IEducationalQualification,
    profQualification:IProfessionalQualification
}
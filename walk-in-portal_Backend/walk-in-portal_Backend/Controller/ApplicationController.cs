using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using walk_in_portal_Backend.Models;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Asn1.X509;
using walk_in_portal_Backend.Dtos;

namespace walk_in_portal_Backend.Controller
{
    [Route("api/v1")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly DbWalkInPortalContext _appDbContext;
        
        public ApplicationController(DbWalkInPortalContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        //api for job listing page
        [HttpGet("getAllDrives")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetApplication()
        {
            Console.Write("Hello");
            var result = await  _appDbContext.TblJobRoleDetails.Select(c => new
            {
                application_id = c.WalkInApplicationId,
                application = new
                {
                    title=c.WalkInApplication.Title,
                    location=c.WalkInApplication.Location,
                    additionalInformation=c.WalkInApplication.AdditionalInformation,
                    general_instruction=c.WalkInApplication.GeneralInstruction,
                    exam_instruction=c.WalkInApplication.ExamInstruction,
                    systemRequirements=c.WalkInApplication.SystemRequirements,
                    application_process=c.WalkInApplication.ApplicationProcess,
                    start_date=c.WalkInApplication.StartDate,
                    end_date=c.WalkInApplication.EndDate,
                },
                job_role=c.JobRole.JobName,
            }).GroupBy(c=> c.application_id).ToListAsync();
            
            
            
            var final = new List<Dictionary<string, object>>();
            
            foreach (var innerList in result)
            {
                var applicationId = 0;
                var jobRoles = new List<string>();
                object application=new TblWalkInApplication();
                foreach (var item in innerList)
                {
                    applicationId = item.application_id;
                    jobRoles.Add(item.job_role);
                    application = item.application;
                }
                
                final.Add(new Dictionary<string, object>
                {
                    { "application_id", applicationId },
                    { "job_role", jobRoles },
                    { "application", application}
                });
            }
            
            return Ok(final);
        }

        //api for job details page
        [HttpGet("getDrive/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetDrive(int id)
        {
            var applications = await _appDbContext.TblJobRoleDetails
                .Where(c => c.WalkInApplicationId ==  id)
                .Select(c => new
                {
                    application_id = c.WalkInApplicationId,
                    application = new
                    {
                        title=c.WalkInApplication.Title,
                        location=c.WalkInApplication.Location,
                        additionalInformation=c.WalkInApplication.AdditionalInformation,
                        general_instruction=c.WalkInApplication.GeneralInstruction,
                        exam_instruction=c.WalkInApplication.ExamInstruction,
                        systemRequirements=c.WalkInApplication.SystemRequirements,
                        application_process=c.WalkInApplication.ApplicationProcess,
                        start_date=c.WalkInApplication.StartDate,
                        end_date=c.WalkInApplication.EndDate,
                    },
                    job_role = c.JobRole.JobName,
                    role_requirements = c.RoleRequirements,
                    role_descriptions = c.RoleDescription,
                    package = c.GrossCompensationPackage
                })
                .GroupBy(c => c.application_id)
                .ToListAsync();

            if (applications == null)
            {
                return NotFound();
            }
            
            var timeSlot = await _appDbContext.TblWalkInApplicationTimeSlots
                .Where(c => c.WalkInApplicationId ==  id)
                .Select(c => new
                {
                    application_id = c.WalkInApplicationId,
                    start_time=c.TimeSlot.StartTime,
                    end_time=c.TimeSlot.EndTime
                })
                .GroupBy(c=> c.application_id)
                .ToListAsync();
            

            var updatedTimeSlot = new List<Dictionary<string, object>>();

            foreach (var slots in timeSlot)
            {
                var times = new List<Dictionary<string, object>>();
                foreach (var subSlots in slots)
                {
                    times.Add(new Dictionary<string,object>
                    {
                        {"start_time", Convert.ToString(subSlots.start_time)},
                        {"end_time", Convert.ToString(subSlots.end_time)}
                    });
                }

                updatedTimeSlot.Add(new Dictionary<string, object>
                {
                    {"timestamp", times},
                });
            }
            
            var updatedApplication = new List<Dictionary<string, object>>();

            foreach (var innerList in applications)
            {
                var applicationId = 0;
                var jobRolesWithDetails = new List<Dictionary<string, object>>();
                object application=new TblWalkInApplication();
                foreach (var item in innerList)
                {
                    jobRolesWithDetails.Add(
                        new Dictionary<string, object>
                        {
                            { "job_role", item.job_role },
                            { "requirements", item.role_requirements },
                            { "roleDescription", item.role_descriptions },
                            { "package", item.package }
                        }
                    );
                    application = item.application;
                    applicationId=item.application_id;
                }
                
                updatedApplication.Add(new Dictionary<string, object>
                {
                    {"application_id", applicationId},
                    { "application", application},
                    { "jobRoleWithDetails", jobRolesWithDetails},
                    { "time_slot", updatedTimeSlot[0]}
                });
            }
            
            return Ok(updatedApplication);
        }
        
        //api for user Applied Job Application
        [HttpPost("applyJob")]
        [Authorize]
        public async Task<IActionResult> ApplyJobAsync([FromBody] UserAppliedJobDTO jobApplication)
        {
            if (jobApplication == null)
            {
                return BadRequest();
            }
            int applicationId = jobApplication.JobId;
            int userId = jobApplication.UserId;
            string applicantResume = jobApplication.UserResume;
    
            string timeRange = jobApplication.TimeSlot;

            string[] times = timeRange.Split('-');

            if (times.Length == 2)
            {
                TimeSpan starTime = TimeSpan.ParseExact(times[0].Trim(),"h\\:mm\\:ss",null);
                TimeSpan endTime = TimeSpan.ParseExact(times[1].Trim(),"h\\:mm\\:ss",null);
                
                
                int dateId = await _appDbContext.TblTimeSlots
                    .Where(c => c.StartTime == starTime && c.EndTime == endTime).Select(c => c.Id)
                    .FirstAsync();

                List<int> role_id = new List<int>();

                foreach (var role in jobApplication.JobRoles)
                {
                    var jobId = await _appDbContext.TblJobRoles.Where(c => c.JobName == role).Select(c => c.Id)
                        .FirstAsync();
                    role_id.Add(jobId);
                }

                var user_applied_job = new TblUserAppliedJob
                {
                    WalkInApplicationId = applicationId,
                    UserId = userId,
                    TimeSlotId = dateId,
                    Resume = applicantResume
                };

                await _appDbContext.TblUserAppliedJobs.AddAsync(user_applied_job);
                await _appDbContext.SaveChangesAsync();

                var userAppliedJobId = user_applied_job.Id;

                foreach (var ids in role_id)
                {
                    var JobRoleName = new TblUserAppliedJobRoleName
                    {
                        JobRoleId = ids,
                        UserAppliedJobId = userAppliedJobId
                    };

                    await _appDbContext.TblUserAppliedJobRoleNames.AddAsync(JobRoleName);
                    await _appDbContext.SaveChangesAsync();
                }
                return Ok("Applied Successfully");
            }
            else
            {
                return ValidationProblem(jobApplication.TimeSlot);
            }
        }
    }
}


﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using walk_in_portal_Backend.Models;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.X509;

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
        
        
        
        // [HttpGet("getAllDrives")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public async Task<IActionResult> GetAllDrives()
        // {
        //     var result = await _appDbContext.TblWalkInApplications.ToListAsync();
        //     return Ok(result);
        // }

        [HttpGet("getAllDrives")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetApplication()
        {
            var result = await  _appDbContext.TblJobRoleDetails.Select(c => new
            {
                application_id = c.WalkInApplicationId,
                application = c.WalkInApplication,
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

        [HttpGet("getDrive/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDrive(int id)
        {
            var applications = await _appDbContext.TblJobRoleDetails
                .Where(c => c.WalkInApplicationId ==  id)
                .Select(c => new
                {
                    application_id = c.WalkInApplicationId,
                    application = c.WalkInApplication,
                    job_role = c.JobRole.JobName,
                    role_requirements = c.RoleRequirements,
                    role_descriptions = c.RoleDescription,
                    package = c.GrossCompensationPackage
                })
                .GroupBy(c => c.application_id)
                .ToListAsync();

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
                var startTime = new List<string>();
                var endTime = new List<string>();
                foreach (var subSlots in slots)
                {
                    startTime.Add(Convert.ToString(subSlots.start_time));
                    endTime.Add(Convert.ToString(subSlots.end_time));
                }

                updatedTimeSlot.Add(new Dictionary<string, object>
                {
                    { "start_time", startTime },
                    { "end_time", endTime }
                });
            }
            
            var updatedApplication = new List<Dictionary<string, object>>();

            foreach (var innerList in applications)
            {
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
                }
                
                updatedApplication.Add(new Dictionary<string, object>
                {
                    { "application", application},
                    { "jobRoleWithDetails", jobRolesWithDetails},
                    { "time_slot", updatedTimeSlot[0]}
                });
            }
            
            return Ok(updatedApplication);
        }
    }
}


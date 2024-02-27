using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using walk_in_portal_Backend.Models;

namespace walk_in_portal_Backend.Controller;

[Route("api/v1")]
[ApiController]

public class RegistrationFormDetailsController : ControllerBase
{
    private readonly DbWalkInPortalContext _appDbContext;
        
    public RegistrationFormDetailsController(DbWalkInPortalContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    //api for getting job roles for registration form
    [HttpGet("getJobRoles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetJobRoles()
    {
        var jobRoles = await _appDbContext.TblJobRoles.Select(c => c.JobName).ToListAsync();
        return Ok(jobRoles);
    }
        
        
    //api for getting qualifications for registration form
    [HttpGet("getQualifications")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetQualifications()
    {
        var qualifications = await _appDbContext.TblQualifications.Select(c => c.Name).ToListAsync();
        return Ok(qualifications);
    }
    
    //api for getting colleges for registration form
    [HttpGet("getColleges")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetColleges()
    {
        var colleges = await _appDbContext.TblQualificationsColleges.Select(c =>  c.Name).ToListAsync();
        return Ok(colleges);
    }
    
    //api for getting streams for registration form
    [HttpGet("getStreams")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStreams()
    {
        var streams = await _appDbContext.TblStreams.Select(c => c.Name).ToListAsync();
        return Ok(streams);
    }
    
    //api for getting technologies for registration form
    [HttpGet("getTechnologies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTechnologies()
    {
        var technologies = await _appDbContext.TblTechnologies.Select(c => c.Name).ToListAsync();
        return Ok(technologies);
    }
}
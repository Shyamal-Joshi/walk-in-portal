using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using walk_in_portal_Backend.Dtos;
using walk_in_portal_Backend.Models;

namespace walk_in_portal_Backend.Controller;

[Route("api/v1")]
[ApiController]

public class UserRegistrationController : ControllerBase
{
    private readonly DbWalkInPortalContext _appDbContext;
        
    public UserRegistrationController(DbWalkInPortalContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    //api for registering new user into database
    [HttpPost("/register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistration user)
    {   
        //college
        //technology
        if(user== null) return BadRequest();
        
        var userPersonalInfo = new TblUserInformation()
        {
            EmailId = user.PersonalInfo.Email,
            Password = "demo@123",
            FirstName = user.PersonalInfo.FirstName,
            LastName = user.PersonalInfo.LastName,
            PhoneNumber = user.PersonalInfo.PhoneNumber,
            ProfilePhoto = user.PersonalInfo.ProfilePhotoUrl,
            Resume = user.PersonalInfo.ResumePath,
            Referrer = user.PersonalInfo.ReferralName,
            NewsLetter = Convert.ToSByte(user.PersonalInfo.Newsletter),
            PortfolioUrl = user.PersonalInfo.PortfolioUrl,
            UserRole = "fresher"
        };

        await _appDbContext.TblUserInformations.AddAsync(userPersonalInfo);
        await _appDbContext.SaveChangesAsync();
        
        List<int> role_id = new List<int>();

        foreach (var role in user.PersonalInfo.PreferredJobRoles)
        {
            var jobId = await _appDbContext.TblJobRoles.Where(c => c.JobName == role).Select(c => c.Id)
                .FirstAsync();
            role_id.Add(jobId);
        }

        var userid = userPersonalInfo.Id;
        
        foreach (var ids in role_id)
        {
            var JobRoleName = new TblUserPreferenceJobeRole
            {
                JobRoleId = ids,
                UserId = userid
            };

            await _appDbContext.TblUserPreferenceJobeRoles.AddAsync(JobRoleName);
            await _appDbContext.SaveChangesAsync();
        }

        var collegeName = user.EduQualification.College;
        
        var collegeId = await _appDbContext.TblQualificationsColleges.Where(c => c.Name == collegeName).Select(c => c.Id)
         .FirstOrDefaultAsync();

        if (collegeId ==  0)
        {
            var newCollege = new TblQualificationsCollege()
            {
                Name = user.EduQualification.OtherCollege,
                Location = user.EduQualification.CollegeLocation
            };

            await _appDbContext.TblQualificationsColleges.AddAsync(newCollege);
            await _appDbContext.SaveChangesAsync();

            collegeId = newCollege.Id;
        }

        var educationalQualification = new TblEducationQualification()
        {
            UserId = userid,
            AggregatedPercentage = Convert.ToInt32(user.EduQualification.AggregatedPercentage),
            YearOfPassing = Convert.ToInt32(user.EduQualification.YearOfPassing),
            QualificationId = await _appDbContext.TblQualifications.Where(c =>  c.Name ==  user.EduQualification.Qualification).Select(c =>  c.Id).FirstAsync(),
            StreamId =  await _appDbContext.TblStreams.Where(c =>  c.Name ==  user.EduQualification.Stream).Select(c =>  c.Id).FirstAsync(),
            CollegeId = collegeId,
            Experience = user.ProfQualification.ApplicationType,
        };
        
        await _appDbContext.TblEducationQualifications.AddAsync(educationalQualification);
        await _appDbContext.SaveChangesAsync();

        if (user.ProfQualification.ApplicationType == "fresher")
        {
            var fresherQualification = new TblProfessionalQualificationFresher()
            {
                UserId = userid,
                AttemptedZeusTest = Convert.ToSByte(user.ProfQualification.PreviouslyApplied),
                RoleAttemptedZeusTest = user.ProfQualification.PreviouslyAppliedRole,
            };
            
            await _appDbContext.TblProfessionalQualificationFreshers.AddAsync(fresherQualification);
            await _appDbContext.SaveChangesAsync();
            
            List<int> tech_id = new List<int>();

            foreach (var tech in user.ProfQualification.FamiliarTechnologies)
            {
                var techId = await _appDbContext.TblTechnologies.Where(c => c.Name == tech).Select(c => c.Id)
                    .FirstAsync();
                tech_id.Add(techId);
            }
            
            foreach (var ids in tech_id)
            {
                var TechnologyName = new TblFresherTechnology()
                {
                    FresherId = fresherQualification.Id,
                    TechnologyId = ids
                };

                await _appDbContext.TblFresherTechnologies.AddAsync(TechnologyName);
                await _appDbContext.SaveChangesAsync();
            }
        }
        else
        {
            var professionalQualification = new TblProfessionalQualificationExperienced()
            {
                UserId = userid,
                AttemptedZeusTest = Convert.ToSByte(user.ProfQualification.PreviouslyApplied),
                RoleAttemptedZeusTest = user.ProfQualification.PreviouslyAppliedRole,
                YearsOfExperience = user.ProfQualification.YearsOfExperience,
                CurrentCtc = Convert.ToDouble(user.ProfQualification.CurrentCtc) ,
                ExpectedCtc = Convert.ToDouble(user.ProfQualification.ExpectedCtc),
                NoticePeriod = Convert.ToSByte(user.ProfQualification.NoticePeriod),
                EndDateNoticePeriod = user.ProfQualification.NoticePeriodDate,
                NoticePeriodLength = user.ProfQualification.NoticePeriodDuration,
            };
            
            await _appDbContext.TblProfessionalQualificationExperienceds.AddAsync(professionalQualification);
            await _appDbContext.SaveChangesAsync();
            
            List<int> fami_tech_id = new List<int>();

            foreach (var tech in user.ProfQualification.FamiliarTechnologies)
            {
                var techId = await _appDbContext.TblTechnologies.Where(c => c.Name == tech).Select(c => c.Id)
                    .FirstAsync();
                fami_tech_id.Add(techId);
            }
            
            foreach (var ids in fami_tech_id)
            {
                var TechnologyName = new TblExperienceFamiliarTechnology()
                {
                    ExperiencedUserId = professionalQualification.Id,
                    FamiliarTechnologyId = ids
                };

                await _appDbContext.TblExperienceFamiliarTechnologies.AddAsync(TechnologyName);
                await _appDbContext.SaveChangesAsync();
            }
            
            List<int> exp_tech_id = new List<int>();

            foreach (var tech in user.ProfQualification.ExpertiseTechnology)
            {
                var techId = await _appDbContext.TblTechnologies.Where(c => c.Name == tech).Select(c => c.Id)
                    .FirstAsync();
                exp_tech_id.Add(techId);
            }
            
            foreach (var ids in exp_tech_id)
            {
                var TechnologyName = new TblExperienceExpertiseTechnology()
                {
                    ExperiencedUserId = professionalQualification.Id,
                    ExpertiseTechnologyId = ids
                };

                await _appDbContext.TblExperienceExpertiseTechnologies.AddAsync(TechnologyName);
                await _appDbContext.SaveChangesAsync();
            }
        }
        
        return Ok("User Added");
    }
}
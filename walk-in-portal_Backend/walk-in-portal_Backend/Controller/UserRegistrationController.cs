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
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistration user)
    {   
        //college
        //technology
        Console.WriteLine(user);
        if(user== null) return BadRequest();
        
        var userPersonalInfo = new TblUserInformation()
        {
            EmailId = user.PersonalInfo.email,
            Password = "demo@123",
            FirstName = user.PersonalInfo.firstName,
            LastName = user.PersonalInfo.lastName,
            PhoneNumber = user.PersonalInfo.phoneNumber,
            ProfilePhoto = user.PersonalInfo.profilePhotoUrl,
            Resume = user.PersonalInfo.resumePath,
            Referrer = user.PersonalInfo.referralName,
            NewsLetter = Convert.ToSByte(user.PersonalInfo.newsletter),
            PortfolioUrl = user.PersonalInfo.portfolioUrl,
            UserRole = "fresher"
        };

        await _appDbContext.TblUserInformations.AddAsync(userPersonalInfo);
        await _appDbContext.SaveChangesAsync();
        
        List<int> role_id = new List<int>();

        foreach (var role in user.PersonalInfo.preferredJobRoles)
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

        var collegeName = user.EduQualification.college;
        
        var collegeId = await _appDbContext.TblQualificationsColleges.Where(c => c.Name == collegeName).Select(c => c.Id)
         .FirstOrDefaultAsync();

        if (collegeId ==  0)
        {
            var newCollege = new TblQualificationsCollege()
            {
                Name = user.EduQualification.otherCollege,
                Location = user.EduQualification.collegeLocation
            };

            await _appDbContext.TblQualificationsColleges.AddAsync(newCollege);
            await _appDbContext.SaveChangesAsync();

            collegeId = newCollege.Id;
        }

        var educationalQualification = new TblEducationQualification()
        {
            UserId = userid,
            AggregatedPercentage = Convert.ToInt32(user.EduQualification.aggregatedPercentage),
            YearOfPassing = Convert.ToInt32(user.EduQualification.yearOfPassing),
            QualificationId = await _appDbContext.TblQualifications.Where(c =>  c.Name ==  user.EduQualification.qualification).Select(c =>  c.Id).FirstAsync(),
            StreamId =  await _appDbContext.TblStreams.Where(c =>  c.Name ==  user.EduQualification.stream).Select(c =>  c.Id).FirstAsync(),
            CollegeId = collegeId,
            Experience = user.ProfQualification.applicationType,
        };
        
        await _appDbContext.TblEducationQualifications.AddAsync(educationalQualification);
        await _appDbContext.SaveChangesAsync();

        if (user.ProfQualification.applicationType == "fresher")
        {
            var fresherQualification = new TblProfessionalQualificationFresher()
            {
                UserId = userid,
                AttemptedZeusTest = Convert.ToSByte(user.ProfQualification.previouslyApplied),
                RoleAttemptedZeusTest = user.ProfQualification.previouslyAppliedRole,
            };
            
            await _appDbContext.TblProfessionalQualificationFreshers.AddAsync(fresherQualification);
            await _appDbContext.SaveChangesAsync();
            
            List<int> tech_id = new List<int>();

            foreach (var tech in user.ProfQualification.familiarTechnologies)
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
            return Ok("User Added");
        }
        else
        {
            
            var professionalQualification = new TblProfessionalQualificationExperienced()
            {
                UserId = userid,
                AttemptedZeusTest = Convert.ToSByte(user.ProfQualification.previouslyApplied),
                RoleAttemptedZeusTest = user.ProfQualification.previouslyAppliedRole,
                YearsOfExperience = user.ProfQualification.yearsOfExperience,
                CurrentCtc = Convert.ToDouble(user.ProfQualification.currentCtc) ,
                ExpectedCtc = Convert.ToDouble(user.ProfQualification.expectedCtc),
                NoticePeriod = Convert.ToSByte(user.ProfQualification.noticePeriod),
                EndDateNoticePeriod = user.ProfQualification.noticePeriodDate,
                NoticePeriodLength = user.ProfQualification.noticePeriodDuration,
            };
            
            await _appDbContext.TblProfessionalQualificationExperienceds.AddAsync(professionalQualification);
            await _appDbContext.SaveChangesAsync();
            
            List<int> fami_tech_id = new List<int>();

            foreach (var tech in user.ProfQualification.familiarTechnologies)
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

            foreach (var tech in user.ProfQualification.expertiseTechnology)
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
            return Ok("User Added");
        }
        
        return Ok("User Added");
    }
}
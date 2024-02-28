namespace walk_in_portal_Backend.Dtos;

public class UserRegistration
{
    public PersonalInformation PersonalInfo { get; set; }
    public EducationalQualification EduQualification { get; set; }
    public ProfessionalQualification ProfQualification { get; set; }
}
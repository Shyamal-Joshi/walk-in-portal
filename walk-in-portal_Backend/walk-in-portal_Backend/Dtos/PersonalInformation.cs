namespace walk_in_portal_Backend.Dtos;

public class PersonalInformation
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ResumePath { get; set; }
    public string PortfolioUrl { get; set; }
    public string ProfilePhotoUrl { get; set; }
    public List<string> PreferredJobRoles { get; set; }
    public string ReferralName { get; set; }
    public bool Newsletter { get; set; }
}
namespace walk_in_portal_Backend.Dtos;

public class PersonalInformation
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }
    public string resumePath { get; set; }
    public string portfolioUrl { get; set; }
    public string profilePhotoUrl { get; set; }
    public List<string> preferredJobRoles { get; set; }
    public string referralName { get; set; }
    public bool newsletter { get; set; }
}
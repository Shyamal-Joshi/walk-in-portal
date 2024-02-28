namespace walk_in_portal_Backend.Dtos;

public class ProfessionalQualification
{
    public string ApplicationType { get; set; }
    public List<string> FamiliarTechnologies { get; set; }
    public string OtherFamiliarTechnologies { get; set; }
    public bool PreviouslyApplied { get; set; }
    public string PreviouslyAppliedRole { get; set; }
    public int YearsOfExperience { get; set; }
    public decimal CurrentCtc { get; set; }
    public decimal ExpectedCtc { get; set; }
    public List<string> ExpertiseTechnology { get; set; }
    public string OtherExpertiseTechnology { get; set; }
    public bool NoticePeriod { get; set; }
    public int NoticePeriodDuration { get; set; }
    public DateTime NoticePeriodDate { get; set; }
}
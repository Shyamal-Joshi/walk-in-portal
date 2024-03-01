namespace walk_in_portal_Backend.Dtos;

public class ProfessionalQualification
{
    public string applicationType { get; set; }
    public List<string> familiarTechnologies { get; set; }
    public string otherFamiliarTechnologies { get; set; }
    public bool previouslyApplied { get; set; }
    public string previouslyAppliedRole { get; set; }
    public int yearsOfExperience { get; set; }
    public decimal currentCtc { get; set; }
    public decimal expectedCtc { get; set; }
    public List<string> expertiseTechnology { get; set; }
    public string otherExpertiseTechnology { get; set; }
    public bool noticePeriod { get; set; }
    public int noticePeriodDuration { get; set; }
    public DateTime noticePeriodDate { get; set; }
}
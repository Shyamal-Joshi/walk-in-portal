using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblUserInformation
{
    public int Id { get; set; }

    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Resume { get; set; } = null!;

    public string? PortfolioUrl { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Referrer { get; set; }

    public sbyte? NewsLetter { get; set; }

    public string? ProfilePhoto { get; set; }

    public string UserRole { get; set; } = null!;

    public DateTime DtCreated { get; set; }

    public DateTime DtModified { get; set; }

    public virtual TblEducationQualification? TblEducationQualification { get; set; }

    public virtual ICollection<TblProfessionalQualificationExperienced> TblProfessionalQualificationExperienceds { get; set; } = new List<TblProfessionalQualificationExperienced>();

    public virtual ICollection<TblProfessionalQualificationFresher> TblProfessionalQualificationFreshers { get; set; } = new List<TblProfessionalQualificationFresher>();

    public virtual ICollection<TblUserAppliedJob> TblUserAppliedJobs { get; set; } = new List<TblUserAppliedJob>();

    public virtual ICollection<TblUserPreferenceJobeRole> TblUserPreferenceJobeRoles { get; set; } = new List<TblUserPreferenceJobeRole>();
}

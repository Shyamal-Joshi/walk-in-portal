using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblProfessionalQualificationExperienced
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int YearsOfExperience { get; set; }

    public double CurrentCtc { get; set; }

    public double ExpectedCtc { get; set; }

    public sbyte NoticePeriod { get; set; }

    public DateTime? EndDateNoticePeriod { get; set; }

    public int? NoticePeriodLength { get; set; }

    public sbyte AttemptedZeusTest { get; set; }

    public string? RoleAttemptedZeusTest { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual ICollection<TblExperienceExpertiseTechnology> TblExperienceExpertiseTechnologies { get; set; } = new List<TblExperienceExpertiseTechnology>();

    public virtual ICollection<TblExperienceFamiliarTechnology> TblExperienceFamiliarTechnologies { get; set; } = new List<TblExperienceFamiliarTechnology>();

    public virtual TblUserInformation User { get; set; } = null!;
}

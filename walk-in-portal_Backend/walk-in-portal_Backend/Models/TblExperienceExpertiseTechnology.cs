using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblExperienceExpertiseTechnology
{
    public int Id { get; set; }

    public int ExperiencedUserId { get; set; }

    public int ExpertiseTechnologyId { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual TblProfessionalQualificationExperienced ExperiencedUser { get; set; } = null!;

    public virtual TblTechnology ExpertiseTechnology { get; set; } = null!;
}

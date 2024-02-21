using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblExperienceFamiliarTechnology
{
    public int Id { get; set; }

    public int ExperiencedUserId { get; set; }

    public int FamiliarTechnologyId { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual TblProfessionalQualificationExperienced ExperiencedUser { get; set; } = null!;

    public virtual TblTechnology FamiliarTechnology { get; set; } = null!;
}

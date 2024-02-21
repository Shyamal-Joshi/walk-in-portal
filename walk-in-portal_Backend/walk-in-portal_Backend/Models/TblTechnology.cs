using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblTechnology
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual ICollection<TblExperienceExpertiseTechnology> TblExperienceExpertiseTechnologies { get; set; } = new List<TblExperienceExpertiseTechnology>();

    public virtual ICollection<TblExperienceFamiliarTechnology> TblExperienceFamiliarTechnologies { get; set; } = new List<TblExperienceFamiliarTechnology>();

    public virtual ICollection<TblFresherTechnology> TblFresherTechnologies { get; set; } = new List<TblFresherTechnology>();
}

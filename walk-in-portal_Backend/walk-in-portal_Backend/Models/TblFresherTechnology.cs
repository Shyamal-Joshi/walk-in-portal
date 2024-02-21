using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblFresherTechnology
{
    public int Id { get; set; }

    public int FresherId { get; set; }

    public int TechnologyId { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual TblProfessionalQualificationFresher Fresher { get; set; } = null!;

    public virtual TblTechnology Technology { get; set; } = null!;
}

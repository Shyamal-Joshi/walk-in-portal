using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblProfessionalQualificationFresher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public sbyte AttemptedZeusTest { get; set; }

    public string? RoleAttemptedZeusTest { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual ICollection<TblFresherTechnology> TblFresherTechnologies { get; set; } = new List<TblFresherTechnology>();

    public virtual TblUserInformation User { get; set; } = null!;
}

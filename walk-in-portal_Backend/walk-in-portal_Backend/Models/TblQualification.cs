using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblQualification
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual ICollection<TblEducationQualification> TblEducationQualifications { get; set; } = new List<TblEducationQualification>();
}

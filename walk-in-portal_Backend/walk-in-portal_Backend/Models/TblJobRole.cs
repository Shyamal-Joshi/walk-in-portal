using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblJobRole
{
    public int Id { get; set; }

    public string JobName { get; set; } = null!;

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual ICollection<TblJobRoleDetail> TblJobRoleDetails { get; set; } = new List<TblJobRoleDetail>();

    public virtual ICollection<TblUserAppliedJobRoleName> TblUserAppliedJobRoleNames { get; set; } = new List<TblUserAppliedJobRoleName>();

    public virtual ICollection<TblUserPreferenceJobeRole> TblUserPreferenceJobeRoles { get; set; } = new List<TblUserPreferenceJobeRole>();
}

using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblUserPreferenceJobeRole
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int JobRoleId { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual TblJobRole JobRole { get; set; } = null!;

    public virtual TblUserInformation User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblJobRoleDetail
{
    public int Id { get; set; }

    public int WalkInApplicationId { get; set; }

    public int JobRoleId { get; set; }

    public string RoleRequirements { get; set; } = null!;

    public string RoleDescription { get; set; } = null!;

    public string GrossCompensationPackage { get; set; } = null!;

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual TblJobRole JobRole { get; set; } = null!;

    public virtual TblWalkInApplication WalkInApplication { get; set; } = null!;
}

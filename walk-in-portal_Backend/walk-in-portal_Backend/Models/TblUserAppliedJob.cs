using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblUserAppliedJob
{
    public int Id { get; set; }

    public int WalkInApplicationId { get; set; }

    public int UserId { get; set; }

    public int TimeSlotId { get; set; }

    public string Resume { get; set; } = null!;

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual ICollection<TblUserAppliedJobRoleName> TblUserAppliedJobRoleNames { get; set; } = new List<TblUserAppliedJobRoleName>();

    public virtual TblTimeSlot TimeSlot { get; set; } = null!;

    public virtual TblUserInformation User { get; set; } = null!;

    public virtual TblWalkInApplication WalkInApplication { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblTimeSlot
{
    public int Id { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual ICollection<TblUserAppliedJob> TblUserAppliedJobs { get; set; } = new List<TblUserAppliedJob>();

    public virtual ICollection<TblWalkInApplicationTimeSlot> TblWalkInApplicationTimeSlots { get; set; } = new List<TblWalkInApplicationTimeSlot>();
}

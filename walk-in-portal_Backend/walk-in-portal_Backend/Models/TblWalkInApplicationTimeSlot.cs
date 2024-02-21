using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblWalkInApplicationTimeSlot
{
    public int Id { get; set; }

    public int WalkInApplicationId { get; set; }

    public int TimeSlotId { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual TblTimeSlot TimeSlot { get; set; } = null!;

    public virtual TblWalkInApplication WalkInApplication { get; set; } = null!;
}

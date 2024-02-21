using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblWalkInApplication
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? AdditionalInformation { get; set; }

    public string GeneralInstruction { get; set; } = null!;

    public string ExamInstruction { get; set; } = null!;

    public string SystemRequirements { get; set; } = null!;

    public string ApplicationProcess { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime DtCreated { get; set; }

    public DateTime DtModifed { get; set; }

    public virtual ICollection<TblJobRoleDetail> TblJobRoleDetails { get; set; } = new List<TblJobRoleDetail>();

    public virtual ICollection<TblUserAppliedJob> TblUserAppliedJobs { get; set; } = new List<TblUserAppliedJob>();

    public virtual ICollection<TblWalkInApplicationTimeSlot> TblWalkInApplicationTimeSlots { get; set; } = new List<TblWalkInApplicationTimeSlot>();
}

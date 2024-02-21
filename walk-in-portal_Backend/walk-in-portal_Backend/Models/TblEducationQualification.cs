using System;
using System.Collections.Generic;

namespace walk_in_portal_Backend.Models;

public partial class TblEducationQualification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AggregatedPercentage { get; set; }

    public int YearOfPassing { get; set; }

    public int QualificationId { get; set; }

    public int StreamId { get; set; }

    public int CollegeId { get; set; }

    public string Experience { get; set; } = null!;

    public DateTime DtCreated { get; set; }

    public DateTime DtModified { get; set; }

    public virtual TblQualificationsCollege College { get; set; } = null!;

    public virtual TblQualification Qualification { get; set; } = null!;

    public virtual TblStream Stream { get; set; } = null!;

    public virtual TblUserInformation User { get; set; } = null!;
}

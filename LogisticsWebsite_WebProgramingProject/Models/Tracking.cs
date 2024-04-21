using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class Tracking
{
    public int TrackingId { get; set; }

    public string? Status { get; set; }

    public int BillId { get; set; }

    public virtual BillOfLading Bill { get; set; } = null!;
}

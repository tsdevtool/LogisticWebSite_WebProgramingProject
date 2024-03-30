using System;
using System.Collections.Generic;

namespace LogisticWebsite_WebProgramingProject.Models;

public partial class Ship
{
    public int ShipId { get; set; }

    public int ScheduleId { get; set; }

    public string ShipCode { get; set; } = null!;

    public string ShipName { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<BillOfLading> BillOfLadings { get; set; } = new List<BillOfLading>();

    public virtual Schedule Schedule { get; set; } = null!;
}

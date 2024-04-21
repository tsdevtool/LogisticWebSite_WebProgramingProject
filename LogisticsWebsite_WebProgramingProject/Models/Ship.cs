using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class Ship
{
    public int ShipId { get; set; }

    public string ShipCode { get; set; } = null!;

    public string ShipName { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}

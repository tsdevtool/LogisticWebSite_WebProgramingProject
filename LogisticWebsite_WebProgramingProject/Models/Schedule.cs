using System;
using System.Collections.Generic;

namespace LogisticWebsite_WebProgramingProject.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public string Pol { get; set; } = null!;

    public string Pod { get; set; } = null!;

    public DateOnly DayGo { get; set; }

    public DateOnly DayCome { get; set; }

    public byte TransitTime { get; set; }

    public virtual ICollection<Ship> Ships { get; set; } = new List<Ship>();
}

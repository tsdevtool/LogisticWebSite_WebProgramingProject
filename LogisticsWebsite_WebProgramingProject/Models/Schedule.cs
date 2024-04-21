using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? ShipId { get; set; }

    public int Pol { get; set; }

    public int Pod { get; set; }

    public decimal Price { get; set; }

    public DateOnly DayGo { get; set; }

    public TimeOnly? TimeGo { get; set; }

    public DateOnly DayCome { get; set; }

    public virtual ICollection<BillOfLading> BillOfLadings { get; set; } = new List<BillOfLading>();

    public virtual Port PodNavigation { get; set; } = null!;

    public virtual Port PolNavigation { get; set; } = null!;

    public virtual Ship? Ship { get; set; }
}

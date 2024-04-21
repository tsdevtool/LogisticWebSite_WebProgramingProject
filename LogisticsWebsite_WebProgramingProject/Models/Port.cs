using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class Port
{
    public int PortId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Schedule> SchedulePodNavigations { get; set; } = new List<Schedule>();

    public virtual ICollection<Schedule> SchedulePolNavigations { get; set; } = new List<Schedule>();
}

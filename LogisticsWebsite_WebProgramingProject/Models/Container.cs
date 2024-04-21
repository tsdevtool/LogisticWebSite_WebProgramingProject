using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class Container
{
    public int ContainerId { get; set; }

    public double CargoWeight { get; set; }

    public string ContainerSize { get; set; } = null!;

    public byte NumberOfContainer { get; set; }

    public bool Type { get; set; }

    public string PlaceToPickUp { get; set; } = null!;

    public virtual ICollection<BillOfLading> BillOfLadings { get; set; } = new List<BillOfLading>();
}

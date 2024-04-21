using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class BillOfLading
{
    public int BillId { get; set; }

    public int BookingNo { get; set; }

    public int ScheduleId { get; set; }

    public int ContainerId { get; set; }

    public virtual BookingInfomation BookingNoNavigation { get; set; } = null!;

    public virtual ICollection<BookingWareHouse> BookingWareHouses { get; set; } = new List<BookingWareHouse>();

    public virtual Container Container { get; set; } = null!;

    public virtual ICollection<CostsIncurred> CostsIncurreds { get; set; } = new List<CostsIncurred>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual ICollection<Tracking> Trackings { get; set; } = new List<Tracking>();
}

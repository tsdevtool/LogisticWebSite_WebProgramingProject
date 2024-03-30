using System;
using System.Collections.Generic;

namespace LogisticWebsite_WebProgramingProject.Models;

public partial class BillOfLading
{
    public int BillId { get; set; }

    public int BookingNo { get; set; }

    public int? ShipId { get; set; }

    public int ContainerId { get; set; }

    public virtual BookingInfomation BookingNoNavigation { get; set; } = null!;

    public virtual ICollection<BookingWareHouse> BookingWareHouses { get; set; } = new List<BookingWareHouse>();

    public virtual Container Container { get; set; } = null!;

    public virtual ICollection<CostsIncurred> CostsIncurreds { get; set; } = new List<CostsIncurred>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Ship? Ship { get; set; }

    public virtual ICollection<Tracking> Trackings { get; set; } = new List<Tracking>();
}

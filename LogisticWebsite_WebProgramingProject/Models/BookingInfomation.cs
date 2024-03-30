using System;
using System.Collections.Generic;

namespace LogisticWebsite_WebProgramingProject.Models;

public partial class BookingInfomation
{
    public int BookingNo { get; set; }

    public string From { get; set; } = null!;

    public string To { get; set; } = null!;

    public string Commodity { get; set; } = null!;

    public bool PriceOwner { get; set; }

    public DateOnly ShippingDay { get; set; }

    public DateOnly CutOffSi { get; set; }

    public DateOnly CutOffVgm { get; set; }

    public DateOnly CutOffCy { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<BillOfLading> BillOfLadings { get; set; } = new List<BillOfLading>();

    public virtual User User { get; set; } = null!;
}

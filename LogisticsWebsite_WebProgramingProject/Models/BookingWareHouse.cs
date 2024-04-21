using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class BookingWareHouse
{
    public int No { get; set; }

    public int BillId { get; set; }

    public int WhareHouseId { get; set; }

    public DateOnly Dayin { get; set; }

    public virtual BillOfLading Bill { get; set; } = null!;

    public virtual WareHouse WhareHouse { get; set; } = null!;
}

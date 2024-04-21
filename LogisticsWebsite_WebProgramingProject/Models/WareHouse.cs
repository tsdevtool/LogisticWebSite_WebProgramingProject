using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class WareHouse
{
    public int WhareHouseId { get; set; }

    public decimal Price { get; set; }

    public bool Type { get; set; }

    public virtual ICollection<BookingWareHouse> BookingWareHouses { get; set; } = new List<BookingWareHouse>();
}

using System;
using System.Collections.Generic;

namespace LogisticWebsite_WebProgramingProject.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string CountryRegion { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool TypeOfAccount { get; set; }

    public virtual ICollection<BookingInfomation> BookingInfomations { get; set; } = new List<BookingInfomation>();
}

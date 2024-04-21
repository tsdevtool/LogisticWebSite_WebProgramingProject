using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class BookingInfomation
{
    public int BookingNo { get; set; }

    public string From { get; set; } = null!;

    public string To { get; set; } = null!;

    public string Commodity { get; set; } = null!;

    public bool PriceOwner { get; set; }

    public DateOnly CutOffSi { get; set; }

    public double CutOffVgm { get; set; }

    public DateOnly CutOffCy { get; set; }

    public String UserId { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]
    public ApplicationUser? ApplicationUser { get; set; }

    public virtual ICollection<BillOfLading> BillOfLadings { get; set; } = new List<BillOfLading>();

}

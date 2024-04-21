using System;
using System.Collections.Generic;

namespace LogisticsWebsite_WebProgramingProject.Models;

public partial class CostsIncurred
{
    public int CostsIncurredId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateCreate { get; set; }

    public decimal Price { get; set; }

    public int BillId { get; set; }

    public virtual BillOfLading Bill { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}

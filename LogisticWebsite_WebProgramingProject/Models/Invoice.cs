using System;
using System.Collections.Generic;

namespace LogisticWebsite_WebProgramingProject.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int BillId { get; set; }

    public int? CostsIncurredId { get; set; }

    public decimal? Surcharge { get; set; }

    public decimal Total { get; set; }

    public bool Status { get; set; }

    public virtual BillOfLading Bill { get; set; } = null!;

    public virtual CostsIncurred? CostsIncurred { get; set; }
}

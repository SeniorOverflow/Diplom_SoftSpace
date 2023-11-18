using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class Deal
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public DateTime DateDeal { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual ICollection<DealProduct> DealProducts { get; set; } = new List<DealProduct>();

    public virtual User IdUserNavigation { get; set; } = null!;
}

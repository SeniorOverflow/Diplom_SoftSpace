using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class Discount
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public decimal DiscountPrice { get; set; }

    public DateTime DateBegin { get; set; }

    public DateTime DateEnd { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;
}

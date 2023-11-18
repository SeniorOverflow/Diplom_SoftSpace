using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class ShoppingCart
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdUser { get; set; }

    public int Count { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class DlcForProduct
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdSubProduct { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Product IdSubProductNavigation { get; set; } = null!;
}

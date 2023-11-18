using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class LabelProduct
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public string LabelName { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}

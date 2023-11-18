using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class RecommendedProduct
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdUser { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

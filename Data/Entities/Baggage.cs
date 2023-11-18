using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class Baggage
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdDealProduct { get; set; }

    public virtual DealProduct IdDealProductNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

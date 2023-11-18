using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class DealProduct
{
    public int Id { get; set; }

    public int IdDeal { get; set; }

    public int IdProduct { get; set; }

    public int Count { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Baggage> Baggages { get; set; } = new List<Baggage>();

    public virtual Deal IdDealNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Library? Library { get; set; }
}

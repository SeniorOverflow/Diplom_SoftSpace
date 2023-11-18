using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class TypeOfSubscription
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CountDays { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<SubscriptionOnDev> SubscriptionOnDevs { get; set; } = new List<SubscriptionOnDev>();
}

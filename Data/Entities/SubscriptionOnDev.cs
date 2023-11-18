using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class SubscriptionOnDev
{
    public int Id { get; set; }

    public int IdType { get; set; }

    public int IdDev { get; set; }

    public int IdUser { get; set; }

    public DateTime DateBegin { get; set; }

    public DateTime DateEnd { get; set; }

    public virtual Developer IdDevNavigation { get; set; } = null!;

    public virtual TypeOfSubscription IdTypeNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<UserSubOnDev> UserSubOnDevs { get; set; } = new List<UserSubOnDev>();
}

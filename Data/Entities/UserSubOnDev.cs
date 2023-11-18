using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class UserSubOnDev
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdSubscription { get; set; }

    public virtual SubscriptionOnDev IdSubscriptionNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

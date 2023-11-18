using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class Developer
{
    public int Id { get; set; }

    public string NameOfCompany { get; set; } = null!;

    public string UrlOnLogo { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public decimal Score { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SubscriptionOnDev> SubscriptionOnDevs { get; set; } = new List<SubscriptionOnDev>();

    public virtual ICollection<UserDev> UserDevs { get; set; } = new List<UserDev>();
}

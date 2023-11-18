using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public int Lvl { get; set; }

    public decimal Score { get; set; }

    public decimal BonusScore { get; set; }

    public string PictureProfile { get; set; } = null!;

    public virtual ICollection<Baggage> Baggages { get; set; } = new List<Baggage>();

    public virtual ICollection<BlockUser> BlockUsers { get; set; } = new List<BlockUser>();

    public virtual ICollection<ConfirmationEmail> ConfirmationEmails { get; set; } = new List<ConfirmationEmail>();

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();

    public virtual ICollection<LikedCategory> LikedCategories { get; set; } = new List<LikedCategory>();

    public virtual ICollection<LikedProduct> LikedProducts { get; set; } = new List<LikedProduct>();

    public virtual ICollection<RecommendedProduct> RecommendedProducts { get; set; } = new List<RecommendedProduct>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual ICollection<SubscriptionOnDev> SubscriptionOnDevs { get; set; } = new List<SubscriptionOnDev>();

    public virtual ICollection<UserDev> UserDevs { get; set; } = new List<UserDev>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UserSubOnDev> UserSubOnDevs { get; set; } = new List<UserSubOnDev>();
}

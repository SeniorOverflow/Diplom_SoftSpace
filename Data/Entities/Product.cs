using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int IdDev { get; set; }

    public int IdCategory { get; set; }

    public decimal Price { get; set; }

    public string UrlOnProduct { get; set; } = null!;

    public string DefPicture { get; set; } = null!;

    public bool IsDlc { get; set; }

    public bool IsInvisuble { get; set; }

    public virtual ICollection<DealProduct> DealProducts { get; set; } = new List<DealProduct>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<DlcForProduct> DlcForProductIdProductNavigations { get; set; } = new List<DlcForProduct>();

    public virtual ICollection<DlcForProduct> DlcForProductIdSubProductNavigations { get; set; } = new List<DlcForProduct>();

    public virtual ICollection<EventProduct> EventProducts { get; set; } = new List<EventProduct>();

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Developer IdDevNavigation { get; set; } = null!;

    public virtual ICollection<LabelProduct> LabelProducts { get; set; } = new List<LabelProduct>();

    public virtual ICollection<LikedProduct> LikedProducts { get; set; } = new List<LikedProduct>();

    public virtual ICollection<PictureProduct> PictureProducts { get; set; } = new List<PictureProduct>();

    public virtual ICollection<RecommendedProduct> RecommendedProducts { get; set; } = new List<RecommendedProduct>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}

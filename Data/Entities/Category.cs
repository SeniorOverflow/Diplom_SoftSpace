using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string DefPicture { get; set; } = null!;

    public virtual ICollection<LikedCategory> LikedCategories { get; set; } = new List<LikedCategory>();

    public virtual ICollection<PictureCategory> PictureCategories { get; set; } = new List<PictureCategory>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

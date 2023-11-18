using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class PictureProduct
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public string UrlPicture { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}

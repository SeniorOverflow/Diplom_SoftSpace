using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class PictureCategory
{
    public int Id { get; set; }

    public int IdCategory { get; set; }

    public string UrlPicture { get; set; } = null!;

    public virtual Category IdCategoryNavigation { get; set; } = null!;
}

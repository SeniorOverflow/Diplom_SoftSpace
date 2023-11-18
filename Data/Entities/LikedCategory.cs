using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class LikedCategory
{
    public int Id { get; set; }

    public int IdCategory { get; set; }

    public int IdUser { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

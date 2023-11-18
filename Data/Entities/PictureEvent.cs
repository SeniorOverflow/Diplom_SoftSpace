using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class PictureEvent
{
    public int Id { get; set; }

    public int IdEnvent { get; set; }

    public string UrlPicture { get; set; } = null!;

    public virtual EventProduct IdEnventNavigation { get; set; } = null!;
}

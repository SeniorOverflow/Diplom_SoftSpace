using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class EventProduct
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime DateEvent { get; set; }

    public string Description { get; set; } = null!;

    public string DefPicture { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual ICollection<PictureEvent> PictureEvents { get; set; } = new List<PictureEvent>();
}

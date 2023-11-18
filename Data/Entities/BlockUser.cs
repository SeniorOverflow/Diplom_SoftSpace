using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class BlockUser
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public DateTime DateBegin { get; set; }

    public DateTime DateEnd { get; set; }

    public string Cause { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

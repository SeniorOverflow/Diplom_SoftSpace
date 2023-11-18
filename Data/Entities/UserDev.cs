using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class UserDev
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdDev { get; set; }

    public virtual Developer IdDevNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

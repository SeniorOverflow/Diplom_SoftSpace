using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class RoleAbility
{
    public int Id { get; set; }

    public int IdAbilities { get; set; }

    public int IdRole { get; set; }

    public virtual Ability IdAbilitiesNavigation { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;
}

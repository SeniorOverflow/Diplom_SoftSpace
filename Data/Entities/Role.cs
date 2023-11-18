using System;
using System.Collections.Generic;

namespace SoftSpace_web;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<RoleAbility> RoleAbilities { get; set; } = new List<RoleAbility>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

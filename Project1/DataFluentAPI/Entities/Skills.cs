using System;
using System.Collections.Generic;

namespace DataFluentAPI.Entities;

public partial class Skills
{
    public int? UserId { get; set; }

    public string Skill { get; set; } = null!;

    public string? Proficiency { get; set; }

    public int SkillId { get; set; }

    public virtual UserDetails? User { get; set; }
}

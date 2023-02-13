using System;
using System.Collections.Generic;

namespace DataFluentAPI.Entities;

public partial class Company
{
    public int? UserId { get; set; }

    public string? PreviousCompany { get; set; }

    public string? Technology { get; set; }

    public int? Experienceyear { get; set; }

    public int CmpId { get; set; }

    public virtual UserDetails? User { get; set; }
}

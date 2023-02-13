using System;
using System.Collections.Generic;

namespace DataFluentAPI.Entities;

public partial class Education
{
    public int? UserId { get; set; }

    public string? HigherEducation { get; set; }

    public string? University { get; set; }

    public int? Startyear { get; set; }

    public int? Endyear { get; set; }

    public string? Grade { get; set; }

    public int EdId { get; set; }

    public virtual UserDetails? User { get; set; }
}

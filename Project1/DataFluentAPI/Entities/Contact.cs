using System;
using System.Collections.Generic;

namespace DataFluentAPI.Entities;

public partial class Contact
{
    public int? UserId { get; set; }

    public string? Phone { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zipcode { get; set; }

    public int ContactId { get; set; }

    public virtual UserDetails? User { get; set; }
}

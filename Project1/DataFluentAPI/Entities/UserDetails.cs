using System;
using System.Collections.Generic;

namespace DataFluentAPI.Entities;

public partial class UserDetails
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<Company> Companies { get; } = new List<Company>();

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();

    public virtual ICollection<Education> Educations { get; } = new List<Education>();

    public virtual ICollection<Skills> Skills { get; } = new List<Skills>();
}

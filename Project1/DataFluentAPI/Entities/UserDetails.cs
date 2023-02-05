using System;

namespace DataFluentAPI.Entities;

public partial class UserDetails
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Gender { get; set; }

    public int Age { get; set; }

    //public LinkedList<UserDetails> Details { get;set; }
}

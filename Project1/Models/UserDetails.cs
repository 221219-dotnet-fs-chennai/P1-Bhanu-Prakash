namespace Models
{
    public class UserDetails
    {
        public UserDetails() { }
        
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }

        public override string ToString()
        {
            return (
                $"*User-Id                                  -               {Id}" + "\n" +
                $"*FirstName                                -               {Firstname}" + "\n" +
                $"*LastName                                 -               {Lastname}" + "\n" +
                $"*Email                                    -               {Email} " + "\n" +
                $"*Gender                                   -               {Gender} " + "\n" +
                $"*Age                                      -               {Age}");
        }

    }
}
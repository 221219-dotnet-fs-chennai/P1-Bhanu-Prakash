namespace Models
{
    public class Contact
    {

        public Contact() { }
        public Contact(int userid, string phone, string city, string state, string zipcode,int ContactId)
        {
            this.UserId = userid;
            this.Phone = phone;
            this.City = city;
            this.State = state;
            this.Zipcode = zipcode;
            this.ContactId = ContactId;
        }
        public int? UserId { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public int ContactId { get; set; }

        public override string ToString()
        {
            return (
                $"*ContactId                                -               {ContactId} " + "\n" +
                $"*Phone Number                             -               {Phone} " + "\n" +
                $"*City                                     -               {City} " + "\n" +
                $"*State                                    -               {State}" + "\n" +
                $"*ZipCode                                  -               {Zipcode}");
        }
    }
}

using System.Text.RegularExpressions;

namespace Models
{
    public class Contact
    {
        public string phone;
        public string zipcode;

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
        public string? Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (Regex.IsMatch(value, @"^[6-9][0-9]{9}$"))
                {
                    phone = value;
                }
                else
                {
                    System.Console.WriteLine("Invalid Phone Number Format");
                    System.Console.ReadKey();
                }

            }
        }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode
        {
            get
            {
                return zipcode;
            }
            set
            {
                if (Regex.IsMatch(value, @"^[1-9][0-9]{5}$"))
                {
                    zipcode = value;
                }
                else
                {
                    System.Console.WriteLine("Invalid Zipcode" + "\n" +
                        "Zipcode should be of length 6");
                    System.Console.ReadKey();
                }
            }
        }
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

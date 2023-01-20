using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Console
{
    public class Contact
    {
        public Contact() { }
        public Contact(int userid, string phone, string city, string state, string zipcode)
        {
            this.Userid = userid;
            this.Phone = phone; 
            this.City = city;
            this.State = state;
            this.Zipcode = zipcode;
        }
        public int Userid { get; set; }
        public string Phone { get; set; }
        //{
        //    get
        //    {
        //        return phone;
        //    }
        //    set
        //    {
        //        string pattern = @"[6-9]\d{9}";
        //        var IsPhoneCorrect = Regex.IsMatch(phone, pattern);
        //        if (IsPhoneCorrect)
        //            phone = value;
        //        else
        //            throw new InvalidDataException("Please add a valid mobile phone with 10 digits only");
        //    }
        //}
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public override string ToString()
        {
            return ($"{Userid} {Phone} {City} {State} {Zipcode}");
        }
    }
}

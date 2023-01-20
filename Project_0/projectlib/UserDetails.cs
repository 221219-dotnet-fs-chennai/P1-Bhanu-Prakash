using System;
using System.Text.RegularExpressions;

namespace Console
{
    public class UserDetails
    {
        public UserDetails() { }
        public UserDetails(int id, string firstname, string lastname, string email, string password, string gender, int age)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.Password = password;
            this.Gender = gender;
            this.Age = age;
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        //{
        //    get
        //    {
        //        return email;
        //    }
        //    set
        //    {
        //        string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        //        var IsEmailCorrect = Regex.IsMatch(email, pattern);
        //        if (IsEmailCorrect)
        //            email = value;
        //        else
        //            throw new InvalidDataException("Please add a valid Email");
        //    }
        //}
        public string Password { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return ($"{Id} {Firstname} {Lastname} {Email} {Gender} {Age}");
        }

    }
}

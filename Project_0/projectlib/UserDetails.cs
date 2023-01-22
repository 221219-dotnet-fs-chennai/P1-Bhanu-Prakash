using System;
using System.Text.RegularExpressions;

namespace Console
{
    public class UserDetails
    {
        public string email;
        public string password;
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
        public string Email /*{ get; set; }*/
        {
            get
            {
                return email;
            }
            set
            {
                    if (Regex.IsMatch(value, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                    {
                        email = value;
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid Email Format");
                        System.Console.ReadKey();
                    }
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
                {
                    password = value;
                }
                else
                {
                    System.Console.WriteLine("Password is not Strong" + "\n" +
                        "It should contains atleast one Special Characters \"@$!%*?&\" and length should be of minimum 8 characters");
                    System.Console.ReadKey();
                }
            }
        }

        public string Gender { get; set; }
        public int Age { get; set; }

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

using projectlib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class AddRecord : IMenu
    {
        static UserDetails newuser = new UserDetails();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<UserDetails> repo = new SqlRepo(constr);


        public void Display()
        {
            System.Console.WriteLine("Enter Trainer Information");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("[1] Save");
            System.Console.WriteLine("[2] Id - " + newuser.Id);
            System.Console.WriteLine("[3] FirstName - " + newuser.Firstname);
            System.Console.WriteLine("[4] LastName - " + newuser.Lastname);
            System.Console.WriteLine("[5] Email - " + newuser.Email);
            System.Console.WriteLine("[6] Password - " + newuser.Password);
            System.Console.WriteLine("[7] Gender - " + newuser.Gender);
            System.Console.WriteLine("[8] Age - " + newuser.Age);
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Menu";
                case "1":
                    try
                    {
                        Log.Information("Adding record \n" + newuser);
                        repo.Add(newuser);
                        Log.Information("Successful at adding Record!");
                    }
                    catch (System.Exception exc)
                    {
                        Log.Error($"Failed to add Record - {exc.Message}");
                        System.Console.WriteLine(exc.Message);
                        System.Console.WriteLine("Please press Enter to continue");
                        System.Console.ReadLine();
                    }
                    return "Signup";
                case "2":
                    System.Console.WriteLine("Please enter a Id!");
                    newuser.Id = Convert.ToInt32(System.Console.ReadLine());
                    return "AddRecord";
                case "3":
                    System.Console.WriteLine("Please enter a first name!");
                    newuser.Firstname = System.Console.ReadLine();
                    return "AddRecord";
                case "4":
                    System.Console.WriteLine("Please enter a Last name!");
                    newuser.Lastname = System.Console.ReadLine();
                    return "AddRecord";
                case "5":
                    System.Console.WriteLine("Please enter Email!");
                    newuser.Email = System.Console.ReadLine();
                    return "AddRecord";
                case "6":
                    System.Console.WriteLine("Please enter Password");
                    newuser.Password = System.Console.ReadLine();
                    return "AddRecord";
                case "7":
                    System.Console.WriteLine("Please enter Gender");
                    newuser.Gender = System.Console.ReadLine();
                    return "AddRecord";
                case "8":
                    System.Console.WriteLine("Please Age");
                    newuser.Age = Convert.ToInt32(System.Console.ReadLine());
                    return "AddRecord";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "AddRecord";
            }
        }
    }
}

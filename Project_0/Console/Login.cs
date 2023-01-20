using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class Login : IMenu
    {
        public void Display()
        {
            System.Console.WriteLine("------Login-------");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("[1] User Details");
            System.Console.WriteLine("[2] Education Details");
            System.Console.WriteLine("[3] Contact Details");
            System.Console.WriteLine("[4] Company Details");
            System.Console.WriteLine("[5] Skills Details");
            System.Console.WriteLine("[6] Delete User");


        }

        public string UserChoice()
        {
            string input = System.Console.ReadLine();
            switch (input)
            {
                case "0":
                    return "Menu";
                case "1":
                    return "GetRecord";
                case "2":
                    return "GetEducation";
                case "3":
                    return "GetContact";
                case "4":
                    return "GetCompany";
                case "5":
                    return "GetSkills";
                case "6":
                    return "Delete";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "Menu";
            }
        }
    }

}

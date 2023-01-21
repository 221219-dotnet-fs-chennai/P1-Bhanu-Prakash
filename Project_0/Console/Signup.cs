using projectlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class Signup : IMenu
    {
        public void Display()
        {
            System.Console.WriteLine("--------Sign Up-----------");
            System.Console.WriteLine("[0] Go Back");
            System.Console.WriteLine("[1] Insert User Details");
            System.Console.WriteLine("[2] Insert Education Details");
            System.Console.WriteLine("[3] Insert Contact Details");
            System.Console.WriteLine("[4] Insert Company Details");
            System.Console.WriteLine("[5] Insert Skills Details");
        }
        public string UserChoice()
        {
            
            string input = System.Console.ReadLine();
            switch (input)
            {
                case "0":
                    return "Menu";
                case "1":
                    return "AddRecord";
                case "2":
                    return "AddEducation";
                case "3":
                    return "AddContact";
                case "4":
                    return "AddCompany";
                case "5":
                    return "AddSkills";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "Menu";
            }
        }

    }
}

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
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************** Signup *****************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
            System.Console.WriteLine("1. Go Back");
            System.Console.WriteLine("2. Insert User Details");
            System.Console.WriteLine("3. Insert Education Details");
            System.Console.WriteLine("4. Insert Contact Details");
            System.Console.WriteLine("5. Insert Company Details");
            System.Console.WriteLine("6. Insert Skills Details");
            System.Console.WriteLine("7. Click to Login");
        }
        public string UserChoice()
        {
            
            string input = System.Console.ReadLine();
            switch (input)
            {
                case "1":
                    return "Menu";
                case "2":
                    return "AddRecord";
                case "3":
                    return "AddEducation";
                case "4":
                    return "AddContact";
                case "5":
                    return "AddCompany";
                case "6":
                    return "AddSkills";
                case "7":
                    return "Validate";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "Menu";
            }
        }

    }
}

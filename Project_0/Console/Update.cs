using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class Update : IMenu
    {
        public void Display()
        {
            System.Console.WriteLine("--------------------Update Information----------------");

            System.Console.WriteLine("[0] Go Back to Previous Page");
            System.Console.WriteLine("[1] Update UserDetails");
            System.Console.WriteLine("[2] Update Skills");
            System.Console.WriteLine("[3] Update Education");
            System.Console.WriteLine("[4] Update Company");
            System.Console.WriteLine("[5] Update Contact");
        }

        public string UserChoice()
        {
            string input = System.Console.ReadLine();
            switch (input)
            {
                case "0":
                    return "Login";
                case "1":
                    return "UpdateDetails";
                case "2":
                    return "UpdateSkills";
                case "3":
                    return "UpdateEducation";
                case "4":
                    return "UpdateCompany";
                case "5":
                    return "UpdateContact";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "Menu";
            }
        }
    }
}

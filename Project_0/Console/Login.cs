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
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("***************************************** Login Successful ************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
            System.Console.WriteLine("1. Trainer Details");
            System.Console.WriteLine("2. Education Details");
            System.Console.WriteLine("3. Contact Details");
            System.Console.WriteLine("4. Company Details");
            System.Console.WriteLine("5. Skills Details");
            System.Console.WriteLine("6. View All User Information");
            System.Console.WriteLine("7. Go Back to Main Menu");
            System.Console.WriteLine("8. Delete User");


        }

        public string UserChoice()
        {
            string input = System.Console.ReadLine();
            switch (input)
            {
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
                    return "view";
                case "7":
                    return "Menu";
                case "8":
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

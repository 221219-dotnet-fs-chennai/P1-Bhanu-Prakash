using projectlib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class AddCompany : IMenu
    {
        static Company newcompany = new Company();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Company> repo = new CompanyRepo(constr);

        public void Display()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************* Experience **************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("Enter Experience Information");
            System.Console.WriteLine("1. Previous Company           -                    " + newcompany.PreviousCompany);
            System.Console.WriteLine("2. Technology                 -                    " + newcompany.Technology);
            System.Console.WriteLine("3. Experience Years           -                    " + newcompany.ExperienceYear);
            System.Console.WriteLine("4. Save");
            System.Console.WriteLine("5. Go Back");
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Please enter Previous Company!");
                    newcompany.PreviousCompany = System.Console.ReadLine();
                    return "AddCompany";
                case "2":
                    System.Console.WriteLine("Please enter Technology!");
                    newcompany.Technology = System.Console.ReadLine().ToString();
                    return "AddCompany";
                case "3":
                    System.Console.WriteLine("Please enter Years of Experience!");
                    newcompany.ExperienceYear = Convert.ToInt32(System.Console.ReadLine());
                    return "AddCompany";
                case "4":
                    try
                    {
                        Log.Information("Adding record \n" + newcompany);
                        newcompany.Userid = AddRecord.Pid();
                        repo.Add(newcompany);
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
                case "5":
                    return "Signup";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "AddCompany";
            }
        }
    }
}

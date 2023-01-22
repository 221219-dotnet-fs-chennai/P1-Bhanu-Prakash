using projectlib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class AddContact : IMenu
    {
        static Contact newcontact = new Contact();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Contact> repo = new ContactRepo(constr);

        public void Display()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************* Contact *****************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("Enter Trainer Information");
            System.Console.WriteLine("1. Phone        -                     " + newcontact.Phone);
            System.Console.WriteLine("2. City         -                     " + newcontact.City);
            System.Console.WriteLine("3. State        -                     " + newcontact.State);
            System.Console.WriteLine("4. Zipcode      -                     " + newcontact.Zipcode);
            System.Console.WriteLine("5. Save");
            System.Console.WriteLine("6. Go Back");
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Please enter Phone Number!");
                    newcontact.Phone = System.Console.ReadLine();
                    return "AddContact";
                case "2":
                    System.Console.WriteLine("Please enter City!");
                    newcontact.City = System.Console.ReadLine();
                    return "AddContact";
                case "3":
                    System.Console.WriteLine("Please enter State!");
                    newcontact.State = System.Console.ReadLine();
                    return "AddContact";
                case "4":
                    System.Console.WriteLine("Please enter ZipCode!");
                    newcontact.Zipcode = System.Console.ReadLine();
                    return "AddContact";
                case "5":
                    try
                    {
                        Log.Information("Adding record \n" + newcontact);
                        newcontact.Userid = AddRecord.Pid();
                        repo.Add(newcontact);
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
                case "6":
                    return "Signup";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "AddContact";
            }
        }
    }
}

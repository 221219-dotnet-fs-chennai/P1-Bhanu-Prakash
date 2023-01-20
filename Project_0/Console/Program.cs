using Console;
using projectlib;
using System.IO;
using Serilog;
using System.Data.SqlClient;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string newpath = "D:/Shit/log.txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(newPath, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();
            bool repeat = true;
            IMenu menu = new Menu();
            while(repeat)
            {
                System.Console.Clear();
                menu.Display();
                string ans = menu.UserChoice();
                switch (ans)
                {
                    case "Menu":
                        menu = new Menu();
                        break;
                    case "Validate":
                        menu = new Validate();
                        break;
                    case "Signup":
                        menu = new Signup();
                        break;
                    case "Login":
                        menu = new Login();
                        break;
                    case "Delete":
                        menu = new Delete();
                        break;
                    case "AddRecord":
                        Log.Information("Displaying Add record menu to data");
                        menu = new AddRecord();
                        break;
                    case "GetRecord":
                        menu = new GetRecord();
                        break;
                    case "UpdateDetails":
                        menu = new UpdateDetails();
                        break;
                    case "AddEducation":
                        menu = new AddEducation();
                        break;
                    case "GetEducation":
                        menu = new GetEducation();
                        break;
                    case "UpdateEducation":
                        menu = new UpdateEducation();
                        break;
                    case "AddCompany":
                        menu = new AddCompany();
                        break;
                    case "GetCompany":
                        menu = new GetCompany();
                        break;
                    case "UpdateCompany":
                        menu = new UpdateCompany();
                        break;
                    case "AddSkills":
                        menu = new AddSkills();
                        break;
                    case "GetSkills":
                        menu = new GetSkills();
                        break;
                    case "UpdateSkills":
                        menu = new UpdateSkills();
                        break;
                    case "AddContact":
                        menu = new AddContact();
                        break;
                    case "GetContact":
                        menu = new GetContact();
                        break;
                    case "UpdateContact":
                        menu= new UpdateContact();
                        break;
                    case "Exit":
                        repeat = false;
                        break;
                    default:
                        System.Console.WriteLine("Page does not exist!");
                        System.Console.WriteLine("Please press Enter to continue");
                        System.Console.ReadLine();
                        break;
                }

            }

        }

    }

}




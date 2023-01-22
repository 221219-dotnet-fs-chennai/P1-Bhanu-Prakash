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
            string path = "../../../Project_0/log.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            Log.Logger = new LoggerConfiguration()
                           .WriteTo.File(path, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
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
                        Log.Information("displaying Menu to the user");
                        menu = new Menu();
                        break;
                    case "Validate":
                        Log.Information("displaying Validation to the user");
                        menu = new Validate();
                        break;
                    case "Signup":
                        Log.Information("creating signup to the user");
                        menu = new Signup();
                        break;
                    case "Login":
                        Log.Information("Access Login to the user");
                        menu = new Login();
                        break;
                    case "Update":
                        Log.Information("displaying Updation to the user");
                        menu = new Update();
                        break;
                    case "Delete":
                        Log.Information("Deleting the user");
                        menu = new Delete();
                        break;
                    case "view":
                        Log.Information("displaying all user Information");
                        menu = new View();
                        break;
                    case "AddRecord":
                        Log.Information("Displaying Add record menu to data");
                        menu = new AddRecord();
                        break;
                    case "GetRecord":
                        Log.Information("Getting details of the user");
                        menu = new GetRecord();
                        break;
                    case "UpdateDetails":
                        Log.Information("Updation of the user details");
                        menu = new UpdateDetails();
                        break;
                    case "AddEducation":
                        Log.Information("Adding Education details to the user");
                        menu = new AddEducation();
                        break;
                    case "GetEducation":
                        Log.Information("Retreiving Education Details");
                        menu = new GetEducation();
                        break;
                    case "UpdateEducation":
                        Log.Information("Updating Educating Details");
                        menu = new UpdateEducation();
                        break;
                    case "AddCompany":
                        Log.Information("Adding Company Details");
                        menu = new AddCompany();
                        break;
                    case "GetCompany":
                        Log.Information("Retreiving company Details");
                        menu = new GetCompany();
                        break;
                    case "UpdateCompany":
                        Log.Information("updating company details");
                        menu = new UpdateCompany();
                        break;
                    case "AddSkills":
                        Log.Information("Adding skills");
                        menu = new AddSkills();
                        break;
                    case "GetSkills":
                        Log.Information("Retreiving the skills");
                        menu = new GetSkills();
                        break;
                    case "UpdateSkills":
                        Log.Information("Updating the skill details");
                        menu = new UpdateSkills();
                        break;
                    case "AddContact":
                        Log.Information("Adding contact details");
                        menu = new AddContact();
                        break;
                    case "GetContact":
                        Log.Information("Retreiving the contact details");
                        menu = new GetContact();
                        break;
                    case "UpdateContact":
                        Log.Information("Updating the contact details");
                        menu = new UpdateContact();
                        break;
                    case "Exit":
                        Log.Information("Exit");
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




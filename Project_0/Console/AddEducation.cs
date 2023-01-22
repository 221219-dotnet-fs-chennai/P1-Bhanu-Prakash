using projectlib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class AddEducation : IMenu
    {
        static Education neweducation = new Education();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Education> repo = new EducationRepo(constr);

        public void Display()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("******************************************* Education *****************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("Enter Trainer Information");
            System.Console.WriteLine("1. HigherEducation         -                    " + neweducation.HigherEducation);
            System.Console.WriteLine("2. University              -                    " + neweducation.university);
            System.Console.WriteLine("3. StartYear               -                    " + neweducation.Startyear);
            System.Console.WriteLine("4. EndYear                 -                    " + neweducation.Endyear);
            System.Console.WriteLine("5. Grade                   -                    " + neweducation.Grade);
            System.Console.WriteLine("6. Save");
            System.Console.WriteLine("7. Go Back");
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Please enter Higher Education!");
                    neweducation.HigherEducation = System.Console.ReadLine();
                    return "AddEducation";
                case "2":
                    System.Console.WriteLine("Please enter University!");
                    neweducation.university = System.Console.ReadLine();
                    return "AddEducation";
                case "3":
                    System.Console.WriteLine("Please enter Start Year!");
                    neweducation.Startyear = Convert.ToInt32(System.Console.ReadLine());
                    return "AddEducation";
                case "4":
                    System.Console.WriteLine("Please enter End Year!");
                    neweducation.Endyear = Convert.ToInt32(System.Console.ReadLine());
                    return "AddEducation";
                case "5":
                    System.Console.WriteLine("Please enter Grade!");
                    neweducation.Grade = System.Console.ReadLine();
                    return "AddEducation";
                case "6":
                    try
                    {
                        Log.Information("Adding record \n" + neweducation);
                        neweducation.Userid = AddRecord.Pid();
                        repo.Add(neweducation);
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
                case "7":
                    return "Signup";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "AddRecord";
            }
        }
    }
}

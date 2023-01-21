using projectlib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class GetSkills : IMenu
    {
        static Skills newskills = new Skills();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Skills> repo = new SkillRepo(constr);
        public void Display()
        {
            System.Console.WriteLine("Please select an option for Skills");
            System.Console.WriteLine("[0] Go back");
            System.Console.WriteLine("[1] Display All Data");
            System.Console.WriteLine("[2] Update Details");
        }
        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Login";
                case "1":
                    Log.Information("Getting all Records");
                    int id = Validate.Pid();
                    var ob = repo.GetAll(id);
                    System.Console.WriteLine("================");
                    System.Console.WriteLine(ob.ToString());
                    Log.Information("Reading records ends");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();

                    return "Login";
                case "2":
                    return "UpdateSkills";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "GetSkills";

            }
        }
    }
}

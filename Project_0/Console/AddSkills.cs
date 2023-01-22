using projectlib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class AddSkills : IMenu
    {
        static Skills newskills = new Skills();
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        ISqlRepo<Skills> repo = new SkillRepo(constr);

        public void Display()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************** Skills *****************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("Enter Experience Information");
            System.Console.WriteLine("1. Primary Skills         -           " + newskills.Primaryskill);
            System.Console.WriteLine("2. Proficiency 1          -           " + newskills.Proficiency1);
            System.Console.WriteLine("3. Secondary Skills       -           " + newskills.Secondaryskill);
            System.Console.WriteLine("4. Proficiency 2          -           " + newskills.Proficiency2);
            System.Console.WriteLine("5. Teritiary Skills       -           " + newskills.Teritiaryskill);
            System.Console.WriteLine("6. Proficiency 3          -           " + newskills.proficiency3);
            System.Console.WriteLine("7. Save");
            System.Console.WriteLine("8. Go Back");
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Please enter Primary Skill!");
                    newskills.Primaryskill = System.Console.ReadLine();
                    return "AddSkills";
                case "2":
                    System.Console.WriteLine("Please enter Primary Skill Proficiency");
                    newskills.Proficiency1 = System.Console.ReadLine();
                    return "AddSkills";
                case "3":
                    System.Console.WriteLine("Please enter Secondary Skills!");
                    newskills.Secondaryskill = System.Console.ReadLine();
                    return "AddSkills";
                case "4":
                    System.Console.WriteLine("Please enter Secondary Skill Proficiency");
                    newskills.Proficiency2 = System.Console.ReadLine();
                    return "AddSkills";
                case "5":
                    System.Console.WriteLine("Please enter Teritiary Skills!");
                    newskills.Teritiaryskill = System.Console.ReadLine();
                    return "AddSkills";
                case "6":
                    System.Console.WriteLine("Please enter Teritiary Skill Proficiency");
                    newskills.proficiency3 = System.Console.ReadLine();
                    return "AddSkills";
                case "7":
                    try
                    {
                        Log.Information("Adding record \n" + newskills);
                        newskills.Userid = AddRecord.Pid();
                        System.Console.WriteLine(newskills.Userid);
                        System.Console.ReadKey();
                        repo.Add(newskills);
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
                case "8":
                    return "Signup";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "AddSkills";
            }
        }
    }
}

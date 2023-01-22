using projectlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class View : IMenu
    {
        static string constr = File.ReadAllText("../../../../Database/log.txt");
        SqlRepo userobj = new SqlRepo(constr);
        
        SkillRepo skillobj = new SkillRepo(constr);
        EducationRepo edobj = new EducationRepo(constr);
        ContactRepo contactobj = new ContactRepo(constr);
        CompanyRepo companyobj = new CompanyRepo(constr);
        int id = Validate.Pid();



        public void Display()
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("******************************************** Trainer Details **********************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine($"{userobj.GetAll(id).ToString()}");

            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************** Skills *****************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine($"{skillobj.GetAll(id).ToString()}");

            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************* Education ***************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine($"{edobj.GetAll(id).ToString()}");

            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************* Contact *****************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine($"{contactobj.GetAll(id).ToString()}");

            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("********************************************* Experience **************************************");
            System.Console.WriteLine("-----------------------------------------------------------------------------------------------");
            System.Console.WriteLine($"{companyobj.GetAll(id).ToString()}");
        }

        public String UserChoice()
        {
            System.Console.WriteLine("Press Enter To Continue");
            System.Console.ReadKey();
            return "Login";
        }
    }
}

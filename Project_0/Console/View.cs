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
            System.Console.WriteLine("------------------User Details--------------");
            System.Console.WriteLine($"{userobj.GetAll(id).ToString()}");
            System.Console.WriteLine("------------------Skill Details--------------");
            System.Console.WriteLine($"{skillobj.GetAll(id).ToString()}");
            System.Console.WriteLine("------------------Education Details--------------");
            System.Console.WriteLine($"{edobj.GetAll(id).ToString()}");
            System.Console.WriteLine("------------------Contact Details--------------");
            System.Console.WriteLine($"{contactobj.GetAll(id).ToString()}");
            System.Console.WriteLine("------------------Experience Details--------------");
            System.Console.WriteLine($"{companyobj.GetAll(id).ToString()}");
        }

        public String UserChoice()
        {
            return "over";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectlib
{
    public class Skills
    {
        public Skills() { }
        public Skills(int userid, string primaryskill, string proficiency1,string Secondaryskill, string proficiency2, string Teritaryskill, string proficiency3)
        {
            this.Userid= userid;
            this.Primaryskill= primaryskill;
            this.Proficiency1= proficiency1;
            this.Secondaryskill = Secondaryskill;
            this.Proficiency2= proficiency2;
            this.Teritaryskill = Teritaryskill;
            this.proficiency3= proficiency3;
        }

        public int Userid { get; set; }
        public string Primaryskill { get; set; }
        public string Proficiency1 { get; set; }
        public string Secondaryskill { get; set; }
        public string Proficiency2 { get; set; }    
        public string Teritaryskill { get; set; }
        public string proficiency3 { get; set; }

        public override string ToString()
        {
            return ($"{Primaryskill} {Proficiency1}" +"\n" +
                $" {Secondaryskill} {Proficiency2} " + "\n" +
                $" {Teritaryskill} {proficiency3}");
        }
    }
}

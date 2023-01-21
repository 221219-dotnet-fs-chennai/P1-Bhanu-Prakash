using Console;
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
        
        public int Userid { get; set; }
        public string Primaryskill { get; set; }
        public string Proficiency1 { get; set; }
        public string Secondaryskill { get; set; }
        public string Proficiency2 { get; set; }    
        public string Teritiaryskill { get; set; }
        public string proficiency3 { get; set; }

        public override string ToString()
        {
            return ($"{Primaryskill} {Proficiency1}" +"\n" +
                $" {Secondaryskill} {Proficiency2} " + "\n" +
                $" {Teritiaryskill} {proficiency3}");
        }
    }
}

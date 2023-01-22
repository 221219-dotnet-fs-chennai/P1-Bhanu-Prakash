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
            return (
                $"*Primary Skill                            -               {Primaryskill} " + "\n" +
                $"*Primary Skill Proficienct                -               {Proficiency1}" + "\n" +
                $"*Secondary Skill Proficiency              -               {Secondaryskill} " + "\n" +
                $"*Secondary Skill Proficiency              -               {Proficiency2} " + "\n" +
                $"*Teritiary Skill                          -               {Teritiaryskill} " + "\n" +
                $"*Teritiary Skill Proficiency              -               {proficiency3}");
        }
    }
}

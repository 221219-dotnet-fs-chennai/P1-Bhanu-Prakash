using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectlib
{
    public class Education
    {
        public Education() { }
        public Education(int userid, string highereducation, string university, int startyear, int endyear, string grade)
        {
            this.Userid = Userid;
            this.HigherEducation = highereducation;
            this.university = university;
            this.Startyear = startyear;
            this.Endyear = endyear;
            this.Grade = grade;
        }

        public int Userid { get; set; }
        public string HigherEducation { get; set; }
        public string university { get; set; }
        public int Startyear { get; set; }
        public int Endyear { get; set; }
        public string Grade { get; set; }

        public override string ToString()
        {
            return (
                $"*Higher Education                         -               {HigherEducation} " + "\n" +
                $"*University                               -               {university} " + "\n" +
                $"*Start Year                               -               {Startyear} " + "\n" +
                $"*End Year                                 -               {Endyear} " + "\n" +
                $"*Grade                                    -               {Grade}");
        }


    }
}

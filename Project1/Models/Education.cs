namespace Models
{
    public class Education
    {
        public Education() { }
        public Education(int UserId, string highereducation, string university, int startyear, int endyear, string grade,int EdId)
        {
            this.UserId = UserId;
            this.HigherEducation = highereducation;
            this.University = university;
            this.Startyear = startyear;
            this.Endyear = endyear;
            this.Grade = grade;
            this.EdId = EdId;
        }

        public int? UserId { get; set; }
        public string? HigherEducation { get; set; }
        public string? University { get; set; }
        public int? Startyear { get; set; }
        public int? Endyear { get; set; }
        public string? Grade { get; set; }

        public int EdId { get; set; }

        public override string ToString()
        {
            return (
                $"*EducationId                              -               {EdId} " + "\n" +
                $"*Higher Education                         -               {HigherEducation} " + "\n" +
                $"*University                               -               {University} " + "\n" +
                $"*Start Year                               -               {Startyear} " + "\n" +
                $"*End Year                                 -               {Endyear} " + "\n" +
                $"*Grade                                    -               {Grade}");
        }
    }
}

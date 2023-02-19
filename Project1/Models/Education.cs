namespace Models
{
    public class Education
    {
        public Education() { }
        public Education(int UserId, string highereducation, string university, int startyear, int endyear, string grade,int EdId)
        {
            this.UserId = UserId;
            this.Degree = highereducation;
            this.University = university;
            this.Startyear = startyear;
            this.Endyear = endyear;
            this.Grade = grade;
            this.EdId = EdId;
        }

        public int? UserId { get; set; }
        public string? Degree { get; set; }
        public string? University { get; set; }
        public int? Startyear { get; set; }
        public int? Endyear { get; set; }
        public string? Grade { get; set; }

        public int EdId { get; set; }

        public override string ToString()
        {
            return (
                $"*EducationId                              -               {EdId} " + "\n" +
                $"*Higher Education                         -               {Degree} " + "\n" +
                $"*University                               -               {University} " + "\n" +
                $"*Start Year                               -               {Startyear} " + "\n" +
                $"*End Year                                 -               {Endyear} " + "\n" +
                $"*Grade                                    -               {Grade}");
        }
    }
}

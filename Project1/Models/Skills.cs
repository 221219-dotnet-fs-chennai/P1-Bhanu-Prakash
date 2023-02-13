namespace Models
{
    public class Skills
    {
        public Skills() { }
        public int? UserId { get; set; }
        public string? Skill { get; set; }
        public string? Proficiency { get; set; }
        public int SkillId { get; set; }


        public override string ToString()
        {
            return (
                $"*SkillID                                  -               {SkillId} " + "\n" +
                $"*Primary Skill                            -               {Skill} " + "\n" +
                $"*Primary Skill Proficienct                -               {Proficiency}");
        }
    }
}

namespace DataFluentAPI.Entities
{
    public class SkillRepo : ISkillRepo
    {
        ProjectContext _context;
        public SkillRepo(ProjectContext context)
        {
            _context = context;
        }

        public Skills Add(Skills skill)
        {
            _context.Add(skill);
            _context.SaveChanges();
            return skill;
        }

        public Skills Delete(int id,string name)
        {
            var mail = _context.Skills.Where(i => i.UserId == id && i.Skill == name).First();
            _context.Remove(mail);
            _context.SaveChanges();
            return mail;
        }

        public IEnumerable<Skills> Get(int id)
        {
            var mail = _context.Skills.Where(m => m.UserId== id).Take(3);
            return mail;
        }

        public List<Skills> GetAll()
        {
            return _context.Skills.ToList();
        }

        public Skills UpdateUser(Skills skill)
        {
            _context.Update(skill);
            _context.SaveChanges();
            return skill;
        }
    }
}

using DataFluentAPI.Entities;

namespace BusinessLogic
{
    public class Validate
    {
        ProjectContext _context;
        public Validate(ProjectContext context)
        {
            _context = context;
        }

        public int Pid(string email)
        {
            int id = 0;
            var res = _context.UserDetails.Where(i => i.Email == email).FirstOrDefault();
            if (res.Email == email)
            {
                id = res.Id;
            }
            return id;
        }

        public Skills GetSkillName(int id, string name)
        {
            return _context.Skills.Where(i => i.SkillId == id && i.Skill == name).First();
        }
    }
}
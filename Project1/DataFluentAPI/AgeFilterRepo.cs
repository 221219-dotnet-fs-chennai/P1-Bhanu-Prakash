using DataFluentAPI.Entities;
using DataFluentAPI.View;


namespace DataFluentAPI
{
    public class AgeFilterRepo : IAgeFilter
    {
        View.ProjectContext _context;
        public AgeFilterRepo(View.ProjectContext context)
        {
            _context = context;
        }

        public IEnumerable<AgeFilter> Filter(int age)
        {
            var mail = _context.AgeFilters.Where(m => m.Age >=age);
            return mail.ToList();
        }

        public IEnumerable<AgeFilter> Filter(string skill)
        {
            var sname = skill.ToLower();
            var mail = _context.AgeFilters.Where(m => m.Skill.ToLower() == sname);
            return mail.ToList();
        }
    }
}

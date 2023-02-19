using DataFluentAPI.Entities;

namespace DataFluentAPI
{
    public class EducationRepo : IEducationRepo
    {
        ProjectContext _context;
        public EducationRepo(ProjectContext context)
        {
            _context = context;
        }
        public Education Add(Education ed)
        {
            _context.Add(ed);
            _context.SaveChanges();
            return ed;
        }

        public Education Delete(int id,string degree)
        {
            var _id=_context.Educations.Where(i => i.UserId == id && i.HigherEducation==degree).FirstOrDefault();
            _context.Remove(_id);
            _context.SaveChanges();
            return _id;
        }

        public IEnumerable<Education> Get(int id)
        {
            var _id = _context.Educations.Where(i => i.UserId == id);
            return _id;
        }

        public List<Education> GetAll()
        {
            return _context.Educations.ToList();
        }

        public Education UpdateEd(Education ed)
        {
            _context.Update(ed);
            _context.SaveChanges();
            return ed;
        }
    }
}

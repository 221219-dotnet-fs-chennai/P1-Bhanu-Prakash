using DataFluentAPI.Entities;

namespace DataFluentAPI
{
    public class CompanyRepo : ICompanyRepo
    {
        ProjectContext _context;
        public CompanyRepo(ProjectContext context)
        {
            _context = context;
        }
        public Company Add(Company ed)
        {
            _context.Add(ed);
            _context.SaveChanges();
            return ed;
        }

        public Company Delete(int id)
        {
            var _id = _context.Companies.Where(i => i.UserId == id).FirstOrDefault();
            _context.Remove(_id);
            _context.SaveChanges();
            return _id;
        }

        public IEnumerable<Company> Get(int id)
        {
            var _id = _context.Companies.Where(i => i.UserId == id);
            return _id;
        }

        public List<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public Company UpdateEd(Company ed)
        {
            _context.Update(ed);
            _context.SaveChanges();
            return ed;
        }
    }
}

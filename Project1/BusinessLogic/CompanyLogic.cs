using DataFluentAPI.Entities;
using DataFluentAPI;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic
{
    public class CompanyLogic : ICompanyLogic
    {
        ProjectContext _context;
        ICompanyRepo _edrepo;
        Validate _id;

        public CompanyLogic(ICompanyRepo edrepo, ProjectContext context, Validate id)
        {
            _edrepo = edrepo;
            _context = context;
            _id = id;
        }

        public Models.Company AddEdDetails(string email, Models.Company ed)
        {
            ed.UserId = _id.Pid(email);
            return Mapper.Map(_edrepo.Add(Mapper.Map(ed)));
        }

        public IEnumerable<Models.Company> GetCompanies()
        {
            return Mapper.Map(_edrepo.GetAll());
        }

        public IEnumerable<Models.Company> Get(string email)
        {
            int id = _id.Pid(email);
            return Mapper.Map(_edrepo.Get(id));
        }

        public Models.Company Remove(string email, string prev)
        {
            int id = _id.Pid(email);
            return Mapper.Map(_edrepo.Delete(id,prev));
        }

        public Company UpdateEd(string email, string prev, Models.Company user)
        {
            int id = _id.Pid(email);
            var sk = _context.Companies.Where(item => item.UserId == id && item.PreviousCompany == prev).First();
            if (sk != null)
            {
                sk.UserId = sk.UserId;
                sk.CmpId= sk.CmpId;
                if (user.PreviousCompany.IsNullOrEmpty() && sk.PreviousCompany != null) sk.PreviousCompany = sk.PreviousCompany;
                else sk.PreviousCompany = user.PreviousCompany;
                if (user.Technology.IsNullOrEmpty() && sk.Technology != null) sk.Technology = sk.Technology;
                else sk.Technology = user.Technology;
                if (user.Experienceyear.ToString().IsNullOrEmpty() && sk.Experienceyear != null) sk.Experienceyear = sk.Experienceyear;
                else sk.Experienceyear = user.Experienceyear;
            }
            return _edrepo.UpdateEd(sk);
        }
    }
}

using DataFluentAPI;
using DataFluentAPI.Entities;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic
{
    public class EducationLogic : IEducationLogic
    {
        ProjectContext _context;
        IEducationRepo _edrepo;
        Validate _id;

        public EducationLogic(IEducationRepo edrepo, ProjectContext context, Validate id)
        {
            _edrepo= edrepo;
            _context= context;  
            _id= id;
        }

        public Models.Education AddEdDetails(string email,Models.Education ed)
        {
            ed.UserId = _id.Pid(email);
            return Mapper.Map(_edrepo.Add(Mapper.Map(ed)));
        }

        public IEnumerable<Models.Education> GetEducations()
        {
            return Mapper.Map(_edrepo.GetAll());
        }

        public IEnumerable<Models.Education> Get(string email)
        {
            int id = _id.Pid(email);
            return Mapper.Map(_edrepo.Get(id));
        }

        public Models.Education Remove(string email, string degree)
        {
            int id = _id.Pid(email);
            return Mapper.Map(_edrepo.Delete(id,degree));
        }

        public Education UpdateEd(string email,string degree, Models.Education user)
        {
            int id = _id.Pid(email);
            var sk = _context.Educations.Where(item => item.UserId == id && item.HigherEducation == degree).First();
            if(sk != null)
            {
                sk.UserId = sk.UserId;
                sk.EdId= sk.EdId;
                if (user.Degree.IsNullOrEmpty() && sk.HigherEducation != null) sk.HigherEducation = sk.HigherEducation;
                else sk.HigherEducation = user.Degree;
                if (user.University.IsNullOrEmpty() && sk.University != null) sk.University = sk.University;
                else sk.University = user.University;
                if (user.Startyear.ToString().IsNullOrEmpty() && sk.Startyear != null) sk.Startyear = sk.Startyear;
                else sk.Startyear = user.Startyear;
                if (user.Endyear.ToString().IsNullOrEmpty() && sk.Endyear != null) sk.Endyear = sk.Endyear;
                else sk.Endyear = user.Endyear;
                if (user.Grade.IsNullOrEmpty() && sk.Grade != null) sk.Grade = sk.Grade;
                else sk.Grade = user.Grade;
            }
            return _edrepo.UpdateEd(sk);
        }
    }
}

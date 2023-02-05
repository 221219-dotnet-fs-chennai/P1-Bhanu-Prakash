//using df=DataFluentAPI;
using DataFluentAPI;
using DataFluentAPI.Entities;
using df = DataFluentAPI.Entities;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        IRepo<df.UserDetails> _repo;
        public Logic(ProjectContext context)
        {
            _repo = new SQLRepo(context);
        }
        //public Logic(IRepo<df.Entities.UserDetails> repo)
        //{
        //    _repo = repo;
        //}

        public df.UserDetails AddUserDetails(Models.UserDetails user)
        {
            return _repo.Add(Mapper.Map(user));
        }
        public IEnumerable<Models.UserDetails> GetUserDetails()
        {
            return Mapper.Map(_repo.GetAll());
        }





    }
}

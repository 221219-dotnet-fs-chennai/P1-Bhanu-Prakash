using DataFluentAPI.Entities;
namespace BusinessLogic
{
    public class Logic : ILogic
    {
        IRepo<UserDetails> _repo;
        public Logic(IRepo<UserDetails> repo)
        {
            _repo = repo;
        }
        //public Logic(IRepo<df.Entities.UserDetails> repo)
        //{
        //    _repo = repo;
        //}



        public Models.UserDetails AddUserDetails(Models.UserDetails user)
        {
            return Mapper.Map(_repo.Add(Mapper.Map(user)));
        }
        public IEnumerable<Models.UserDetails> GetUserDetails()
        {
            return Mapper.Map(_repo.GetAll());
        }
        public Models.UserDetails Get(string email)
        {
            return Mapper.Map(_repo.Get(email));
        }

        public Models.UserDetails Remove(string email, string password)
        {
            var mail = (from e in _repo.GetAll()
                        where e.Email == email && e.Password == password
                        select e).FirstOrDefault();
            return Mapper.Map(_repo.Delete(email, password));
        }

        public Models.UserDetails UpdateUser(string email, Models.UserDetails user)
        {
            var mail = (from e in _repo.GetAll()
                        where e.Email == email
                        select e).FirstOrDefault();
            if (mail != null)
            {
                mail.Firstname = user.Firstname;
                mail.Lastname = user.Lastname;
                mail.Email = email;
                mail.Password = user.Password;
                mail.Gender = user.Gender;
                mail.Age = user.Age;
                mail = _repo.Update(mail);
            }
            return Mapper.Map(mail);
        } 
    }
}

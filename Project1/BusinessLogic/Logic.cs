using DataFluentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            return Mapper.Map((_repo.GetAll()));
        }
        public Models.UserDetails Get(string email)
        {
            return Mapper.Map((_repo.Get(email)));
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
                if (user.Firstname.IsNullOrEmpty() && mail.Firstname != null) mail.Firstname = mail.Firstname;
                else mail.Firstname = user.Firstname;
                if (user.Lastname.IsNullOrEmpty() && mail.Lastname != null) mail.Lastname = mail.Lastname;
                else mail.Lastname = user.Lastname;
                mail.Email = email;
                if (user.Password.IsNullOrEmpty() && mail.Password != null) mail.Password = mail.Password;
                else mail.Password = user.Password;
                if (user.Gender.IsNullOrEmpty() && mail.Gender != null) mail.Gender = mail.Gender;
                else mail.Gender = user.Gender;
                if (user.Age.ToString().IsNullOrEmpty() && mail.Age != null) mail.Age = mail.Age;
                else mail.Age = user.Age;
                mail = _repo.Update(mail);
            }
            return Mapper.Map(mail);
        }

        /*public Models.UserDetails Filter(int age)
        {
            var 

        }*/
    }
}

namespace DataFluentAPI.Entities
{
    public class SQLRepo : IRepo<UserDetails>
    {
        ProjectContext context;
        public SQLRepo(ProjectContext _context)
        {
            context = _context;
        }
        public UserDetails Add(UserDetails user)
        {
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public List<UserDetails> GetAll()
        {
            return context.UserDetails.ToList();
        }

        public UserDetails Get(string email)
        {
            var mail = context.UserDetails.Where(m => m.Email == email).FirstOrDefault();
            return mail;
        }

        public UserDetails Delete(string email,string password)
        {
            var mail = context.UserDetails.Where(m => m.Email == email && m.Password == password).FirstOrDefault();
            context.UserDetails.Remove(mail);
            context.SaveChanges();
            return mail;
        }

        public string Validate(string email,string password)
        {
            var mail = context.UserDetails.Where(m => m.Email == email && m.Password == password).FirstOrDefault();
            return "Match Found";
        }

        public UserDetails Update(UserDetails user)
        {
            context.Update(user);
            context.SaveChanges();
            return user;
        }





        /*public IEnumerable<Entities.UserDetails> GetUserDetails(string? email)
        {
            //throw new NotImplementedException();
            var query = from r in context.UserDetails
                        where r.Email == email
                        select r;
            return query.ToList();
            //return repo.GetAllRestaurants().Where(r=>r.ZipCode == zipcode);
        }*/
    }
}

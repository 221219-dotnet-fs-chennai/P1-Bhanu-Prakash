namespace DataFluentAPI
{
    public class SQLRepo : IRepo<Entities.UserDetails>
    {
        Entities.ProjectContext context;
        public SQLRepo(Entities.ProjectContext _context)
        {
            context = _context;
        }
        public Entities.UserDetails Add(Entities.UserDetails user)
        {
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public List<Entities.UserDetails> GetAll()
        {
            return context.UserDetails.ToList();
        }



        
        //public IEnumerable<Entities.UserDetails> GetUserDetails(int id)
        //{
        //    //throw new NotImplementedException();
        //    var query = from r in context.UserDetails
        //                where r.Id == id
        //                select r;
        //    return query.ToList();
        //    //return repo.GetAllRestaurants().Where(r=>r.ZipCode == zipcode);
        //}
    }
}

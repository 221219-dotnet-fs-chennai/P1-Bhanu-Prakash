using df = DataFluentAPI.Entities;
namespace BusinessLogic
{
    public interface ILogic
    {
        Models.UserDetails AddUserDetails(Models.UserDetails userDetails);
        IEnumerable<Models.UserDetails> GetUserDetails();
        Models.UserDetails Remove(string email, string password);
        Models.UserDetails UpdateUser(string email, Models.UserDetails user);
        Models.UserDetails Get(string email);



    }
}

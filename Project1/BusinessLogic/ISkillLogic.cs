using df = DataFluentAPI.Entities;


namespace BusinessLogic
{
    public interface ISkillLogic
    {
        Models.Skills AddSkillDetails(string email,Models.Skills skills);
        IEnumerable<Models.Skills> GetskillDetails();
        Models.Skills Remove(string email,string password);
        df.Skills UpdateUser(string email, string oldskill, Models.Skills user);
        IEnumerable<Models.Skills> Get(string email);

    }
}

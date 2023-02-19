using df = DataFluentAPI.Entities;

namespace BusinessLogic
{
    public interface IEducationLogic
    {
        Models.Education AddEdDetails(string email, Models.Education ed);

        IEnumerable<Models.Education> GetEducations();

        IEnumerable<Models.Education> Get(string email);

        Models.Education Remove(string email,string degree);

        df.Education UpdateEd(string email,string degree, Models.Education user);
    }
}

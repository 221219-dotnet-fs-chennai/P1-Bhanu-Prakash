using df = DataFluentAPI.Entities;

namespace BusinessLogic
{
    public interface ICompanyLogic
    {
        Models.Company AddEdDetails(string email, Models.Company ed);

        IEnumerable<Models.Company> GetCompanies();

        IEnumerable<Models.Company> Get(string email);

        Models.Company Remove(string email);

        df.Company UpdateEd(string email, Models.Company user);
    }
}

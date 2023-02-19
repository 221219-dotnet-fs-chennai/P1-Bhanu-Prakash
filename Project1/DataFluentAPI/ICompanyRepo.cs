using DataFluentAPI.Entities;


namespace DataFluentAPI
{
    public interface ICompanyRepo
    {
        Company Add(Company t);

        List<Company> GetAll();

        Company Delete(int t,string prev);

        Company UpdateEd(Company t);

        IEnumerable<Company> Get(int t);
    }
}

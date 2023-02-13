using DataFluentAPI.Entities;

namespace DataFluentAPI
{
    public interface IContactRepo
    {
        Contact Add(Contact t);

        List<Contact> GetAll();

        Contact Delete(int t);

        Contact UpdateEd(Contact t);

        IEnumerable<Contact> Get(int t);
    }
}

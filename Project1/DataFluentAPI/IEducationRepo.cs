using DataFluentAPI.Entities;

namespace DataFluentAPI
{
    public interface IEducationRepo
    {

        Education Add(Education t);

        List<Education> GetAll();

        Education Delete(int t,string degree);

        Education UpdateEd(Education t);

        IEnumerable<Education> Get(int t);


    }
}

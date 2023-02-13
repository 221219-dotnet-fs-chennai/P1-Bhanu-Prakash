using DataFluentAPI.Entities;
namespace DataFluentAPI
{
    public interface ISkillRepo
    {
        Skills Add(Skills t);
        List<Skills> GetAll();

        Skills Delete(int t,string t1);

        Skills UpdateUser(Skills t);

        IEnumerable<Skills> Get(int t);
    }
}

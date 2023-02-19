using df=DataFluentAPI.View;
using DataFluentAPI;
using DataFluentAPI.View;

namespace BusinessLogic
{
    public class AgeFilterLogic : IAgeLogic
    {
        df.ProjectContext _context;
        IAgeFilter _age;
        public AgeFilterLogic(IAgeFilter age)
        {
            _age = age;
        }
        public IEnumerable<df.AgeFilter> Fetch(int age)
        {
            return _age.Filter(age);
        }

        public IEnumerable<df.AgeFilter> Fetch(string skill)
        {
            return _age.Filter(skill);
        }

        
    }
}

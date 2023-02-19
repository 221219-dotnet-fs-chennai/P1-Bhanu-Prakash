using DataFluentAPI.View;
using df = DataFluentAPI.View;

namespace BusinessLogic
{
    public interface IAgeLogic
    {
        IEnumerable<df.AgeFilter> Fetch(int age);
        IEnumerable<df.AgeFilter> Fetch(string skill); 
    }
}

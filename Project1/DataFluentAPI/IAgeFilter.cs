using DataFluentAPI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFluentAPI
{
    public interface IAgeFilter
    {
        IEnumerable<AgeFilter> Filter(int age);
        IEnumerable<AgeFilter> Filter(string skill);
    }
}

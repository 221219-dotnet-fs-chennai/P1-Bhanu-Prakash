using Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectlib
{
    public interface ISqlRepo<T>
    {
        T Add(T t);
        List<T> GetAll(int i); 

    }
}

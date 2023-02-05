using df=DataFluentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {
        public df.UserDetails AddUserDetails(Models.UserDetails userDetails);
        //void AddUserDetails(Models.UserDetails newuser);
        IEnumerable<Models.UserDetails> GetUserDetails();
    }
}

using System;
using df = DataFluentAPI.Entities;


namespace BusinessLogic
{
    public interface IContactLogic
    {
        Models.Contact AddEdDetails(string email, Models.Contact ed);

        IEnumerable<Models.Contact> GetContacts();

        IEnumerable<Models.Contact> Get(string email);

        Models.Contact Remove(string email);

        df.Contact UpdateEd(string email, Models.Contact user);
    }
}

using DataFluentAPI.Entities;
using DataFluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic
{
    public class ContactLogic : IContactLogic
    {
        ProjectContext _context;
        IContactRepo _edrepo;
        Validate _id;

        public ContactLogic(IContactRepo edrepo, ProjectContext context, Validate id)
        {
            _edrepo = edrepo; 
            _context = context;
            _id = id;
        }

        public Models.Contact AddEdDetails(string email, Models.Contact ed)
        {
            ed.UserId = _id.Pid(email);
            return Mapper.Map(_edrepo.Add(Mapper.Map(ed)));
        }

        public IEnumerable<Models.Contact> GetContacts()
        {
            return Mapper.Map(_edrepo.GetAll());
        }

        public IEnumerable<Models.Contact> Get(string email)
        {
            int id = _id.Pid(email);
            return Mapper.Map(_edrepo.Get(id));
        }

        public Models.Contact Remove(string email)
        {
            int id = _id.Pid(email);
            return Mapper.Map(_edrepo.Delete(id));
        }

        public Contact UpdateEd(string email, Models.Contact user)
        {
            int id = _id.Pid(email);
            var sk = _context.Contacts.Where(item => item.UserId == id).First();
            if (sk != null)
            {
                sk.UserId = sk.UserId;
                sk.ContactId= sk.ContactId;
                if (sk.City.IsNullOrEmpty() && sk.City != null) sk.City = sk.City;
                else sk.City = user.City;
                if (sk.Phone.IsNullOrEmpty() && sk.Phone != null) sk.Phone = sk.Phone;
                else sk.Phone = user.Phone;
                if (sk.State.ToString().IsNullOrEmpty() && sk.State != null) sk.State = sk.State;
                else sk.State = user.State;
                if (sk.Zipcode.ToString().IsNullOrEmpty() && sk.Zipcode != null) sk.Zipcode = sk.Zipcode;
                else sk.Zipcode = user.Zipcode;
            }
            return _edrepo.UpdateEd(sk);
        }

    }
}

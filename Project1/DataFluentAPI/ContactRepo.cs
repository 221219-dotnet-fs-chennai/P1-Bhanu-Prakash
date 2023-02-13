using DataFluentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFluentAPI
{
    public class ContactRepo : IContactRepo
    {
        ProjectContext _context;
        public ContactRepo(ProjectContext context)
        {
            _context = context;
        }
        public Contact Add(Contact cd)
        {
            _context.Add(cd);
            _context.SaveChanges();
            return cd;
        }

        public Contact Delete(int id)
        {
            var _id = _context.Contacts.Where(i => i.UserId == id).FirstOrDefault();
            _context.Remove(_id);
            _context.SaveChanges();
            return _id;
        }

        public IEnumerable<Contact> Get(int id)
        {
            var _id = _context.Contacts.Where(i => i.UserId == id);
            return _id;
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact UpdateEd(Contact ed)
        {
            _context.Update(ed);
            _context.SaveChanges();
            return ed;
        }
    }
}

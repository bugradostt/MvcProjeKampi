using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _object;
        public ContactManager(IContactDal p)
        {
            _object = p;
        }

        public void AddContact(Contact p)
        {
            _object.Insert(p);
        }

        public void DeleteContact(Contact p)
        {
            _object.Delete(p);
        }

        public Contact GetById(int id)
        {
            return _object.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _object.List();
        }

        public void UpdateContact(Contact p)
        {
            _object.Update(p);
        }
    }
}

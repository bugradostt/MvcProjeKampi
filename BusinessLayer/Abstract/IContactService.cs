using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void AddContact(Contact p);
        void DeleteContact(Contact p);
        void UpdateContact(Contact p);
        Contact GetById(int id);
    }
}

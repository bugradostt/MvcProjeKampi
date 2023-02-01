using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        void AddAdmin(Admin p);
        void DeleteAdmin(Admin p);
        void UpdateAdmin(Admin p);
        Admin GetById(int id);
        Admin GetByUser(Admin p);
        List<Admin> GetList();
      



       
       




    }
}

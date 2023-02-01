using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RoleManager
    {
        IRolDal _rolDal;
        public RoleManager(IRolDal rolDal)
        {
            _rolDal = rolDal;
        }
        public string[] GetRolesForUser(string username)
        {
            return _rolDal.GetRolesForUser(username);
        }
    }
}

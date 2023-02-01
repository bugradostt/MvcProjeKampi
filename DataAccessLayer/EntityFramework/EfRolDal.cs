
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfRolDal:IRolDal
    {
        public string[] GetRolesForUser(string username)
        {
            using (Context context = new Context())
            {
                var _username = context.Admins.FirstOrDefault(x => x.UserName == username);
                return new string[] { _username.UserRole };
            }
        }
    }
}

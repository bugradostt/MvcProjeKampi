using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _object;
        public AdminManager(IAdminDal p)
        {
            _object = p;
        }

        public void AddAdmin(Admin p)
        {


            userName(p);

            password(p);

            //UserRole Şifreme Başlangıç
            /*
            string PasswordUserRole = "";
            PasswordUserRole = p.UserRole;
            char[] KarakterUserRole = PasswordUserRole.ToCharArray();
            foreach (char i in KarakterUserRole)
            {
                PasswordUserRole += Convert.ToChar(i + 7).ToString();
            }
            p.UserRole = PasswordUserRole.Substring(p.UserRole.Length);
            //UserRole Şifreleme Son*/

            _object.Insert(p);
        }

        public void UpdateAdmin(Admin p)
        {
            userName(p);

            password(p);

            _object.Update(p);
        }

        public void DeleteAdmin(Admin p)
        {
            _object.Delete(p);
        }

        public Admin GetById(int id)
        { 
            return _object.Get(x => x.AdminId == id);
        }

        void userName(Admin p)
        {
            //UserName Şifreme Başlangıç
            string PasswordUserName = "";
            PasswordUserName = p.UserName;
            char[] KarakterUserName = PasswordUserName.ToCharArray();

            foreach (char i in KarakterUserName)
            {
                PasswordUserName += Convert.ToChar(i + 3).ToString();
            }
            p.UserName = PasswordUserName.Substring(p.UserName.Length);
            //UserName Şifreleme Son
        }

        void password(Admin p)
        {
            //Password Şifreme Başlangıç
            string PasswordPassword = "";
            PasswordPassword = p.Password;
            char[] KarakterPassword = PasswordPassword.ToCharArray();

            foreach (char i in KarakterPassword)
            {
                PasswordPassword += Convert.ToChar(i + 5).ToString();
            }
            p.Password = PasswordPassword.Substring(p.Password.Length);
            //Password Şifreleme Son

        }

        public Admin GetByUser(Admin p)
        {
            userName(p);

            password(p);

            return _object.Get(x => x.UserName == p.UserName && x.Password == p.Password);
        }

        public List<Admin> GetList()
        {
            return _object.List();
        }

       
        
    }
}

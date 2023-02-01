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
    public class AboutManager : IAboutService
    {
        IAboutDal _object;
        public AboutManager(IAboutDal p)
        {
            _object = p;

        }


        public void AddAbout(About p)
        {
            _object.Insert(p);
        }

        public void DeleteAbout(About p)
        {
            //_object.Delete(p);
            _object.Update(p);
        }

        public About GetById(int id)
        {
            return _object.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _object.List();
        }

        public void UpdateAbout(About p)
        {
            _object.Update(p);
        }
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAboutService
    {
        List<About> GetList();
        void AddAbout(About p);
        void DeleteAbout(About p);
        void UpdateAbout(About p);
        About GetById(int id);
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IYeteneklerService
    {
        List<Yetenekler> GetList();
        void AddYetenekler(Yetenekler p);
        void DeleteYetenekler(Yetenekler p);
        void UpdateYetenekler(Yetenekler p);
        Yetenekler GetById(int id);
    }
}

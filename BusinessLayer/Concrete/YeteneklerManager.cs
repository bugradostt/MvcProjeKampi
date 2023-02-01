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
    public class YeteneklerManager : IYeteneklerService
    {

        IYeteneklerDal _object;
        public YeteneklerManager(IYeteneklerDal p)
        {
            _object = p;
        }


        public void AddYetenekler(Yetenekler p)
        {
            _object.Insert(p);
        }

        public void DeleteYetenekler(Yetenekler p)
        {
            _object.Delete(p);
        }

        public Yetenekler GetById(int id)
        {
            return _object.Get(x => x.YeteneklerId == id);
        }

        public List<Yetenekler> GetList()
        {
            return _object.List();
        }

        public void UpdateYetenekler(Yetenekler p)
        {
            _object.Update(p);
        }
    }
}

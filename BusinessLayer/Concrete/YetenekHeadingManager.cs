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
    public class YetenekHeadingManager : IYetenekHeadingService
    {
        IYetenekHeadingDal _object;
        public YetenekHeadingManager( IYetenekHeadingDal p)
        {
            _object = p;
        }

        public YetenekHeading GetById(int id)
        {
            return _object.Get(x => x.YetenekHeadingId == id);
        }

        public List<YetenekHeading> GetList()
        {
            return _object.List();
        }

        public void UpdateYetenekHeading(YetenekHeading p)
        {
            _object.Update(p);
        }
    }
}

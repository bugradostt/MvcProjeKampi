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
    public class HeadingManager : IHeadingService
    {

        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void AddHeading(Heading p)
        {
            _headingDal.Insert(p);
        }

        public void DeleteHeading(Heading p)
        {
            // _headingDal.Delete(p);
          //  p.HeadingStatus = false;
            _headingDal.Update(p);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List(); 
        }

        public List<Heading> GetListByWriter(int id)
        {

            return _headingDal.List(x=>x.WriterId==id);
        }

        public void UpdateHeading(Heading p)
        {
            _headingDal.Update(p);
        }
    }
}

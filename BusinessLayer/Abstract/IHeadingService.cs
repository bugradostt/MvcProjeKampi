using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void AddHeading(Heading p);
        void DeleteHeading(Heading p);
        void UpdateHeading(Heading p);
        Heading GetById(int id);
    }
}

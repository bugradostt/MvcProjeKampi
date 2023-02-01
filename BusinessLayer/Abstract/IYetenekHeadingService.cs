using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IYetenekHeadingService
    {
        List<YetenekHeading> GetList();
        void UpdateYetenekHeading(YetenekHeading p);
        YetenekHeading GetById(int id);
    }
}

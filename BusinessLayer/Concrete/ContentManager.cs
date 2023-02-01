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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contactDal)
        {
            _contentDal = contactDal;
        }


        public void AddContent(Content p)
        {
            _contentDal.Insert(p);
        }

        public void DeleteContent(Content p)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p));
        }

        public List<Content> GetListById(int id)
        {
            return _contentDal.List(x=>x.HeadingId==id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }

        public void UpdateContent(Content p)
        {
            throw new NotImplementedException();
        }
    }
}

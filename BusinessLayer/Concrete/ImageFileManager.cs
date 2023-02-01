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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _object;
        public ImageFileManager(IImageFileDal p)
        {

            _object = p;
        }

        public void AddImageFile(ImageFile p)
        {
            _object.Insert(p);
        }

        public void DeleteImageFile(ImageFile p)
        {
            _object.Delete(p);
        }

        public ImageFile GetById(int id)
        {
            return _object.Get(x => x.ImageId == id);
        }

        public List<ImageFile> GetList()
        {
            return _object.List();
        }

        public void UpdateImageFile(ImageFile p)
        {
            _object.Update(p);
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
    
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void CategoryAdd(Category p)
        {
            _categoryDal.Insert(p);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public void CategoryDelete(Category p)
        {
            _categoryDal.Delete(p);
        }

        public void CategoryUpdate(Category p)
        {
            _categoryDal.Update(p);
        }

        public Category GetCategoryName(string p)
        {
            return _categoryDal.Get(x => x.CategoryName == p);
        }
    }
}

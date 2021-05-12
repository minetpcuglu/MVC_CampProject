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
        ICategoryDal _categoryDal;  // field türü ICategoryDal  // field da değer ataması yapmak ıcın const metodu olustur

        public CategoryManager(ICategoryDal categorydal)
        {
            _categoryDal = categorydal;
        }

        
        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category); //ICServiden gelen category parametrisini ekle 
        }

        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public Category GetByName(string name)
        {
            return _categoryDal.Get(x => x.CategoryName == name);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public List<Category> StatusIsFalse()
        {
            return _categoryDal.List(x => x.CategoryStatus == false);
        }

        public List<Category> StatusIsTrue()
        {
            return _categoryDal.List(x => x.CategoryStatus == true);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category); //kaegoriden gelen değeri güncelle
        }
    }
}

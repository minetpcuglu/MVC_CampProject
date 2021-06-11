using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category category);//categoryden eklemek için bir tanım yapıldı

        Category GetById(int id);  //dısarıdan bir ıd alıcak

        void DeleteCategory(Category category); //silme işlemi

        void UpdateCategory(Category category); //güncelleme işlemi 

       Category GetByName(string name); //dısarıdan bir isim alıcak

        List<Category> StatusIsTrue();
        List<Category> StatusIsFalse();

    }

  
}

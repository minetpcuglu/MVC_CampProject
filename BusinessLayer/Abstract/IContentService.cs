using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();

        List<Content> GetListHeadingID(int id); //şartlı listeleme
        void ContentAdd(Content content);//categoryden eklemek için bir tanım yapıldı

        Content GetById(int id);  //dısarıdan bir ıd alıcak

        void DeleteContent(Content content); //silme işlemi

        void UpdateContent(Content content); //güncelleme işlemi 

       
    }
}

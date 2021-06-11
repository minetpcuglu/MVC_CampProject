using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public interface IContactService
    {
        List<Contact> GetList();
        void ContactAdd(Contact contact);//categoryden eklemek için bir tanım yapıldı

        Contact GetById(int id);  //dısarıdan bir ıd alıcak

        void DeleteContact(Contact contact); //silme işlemi

        void UpdateContact(Contact contact); //güncelleme işlemi 
    }
}

using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin);
        bool Login(AdminLoginDto admin);
       
        Admin GetById(int id);
        Admin GetByName(String name);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);


       

    }
}

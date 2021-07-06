using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

       

        public void AdminAdd( Admin admin)
        { 
            admin.AdminStatus = true;
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
          
            _adminDal.Update(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetById(int id)
        {
           return _adminDal.Get(x => x.AdminId == id);
        }

        public Admin GetByName(string name)
        {
            return _adminDal.Get(x => x.AdminName == name);
        }

        public List<Admin> GetList()
        {
           return _adminDal.List().Where(x=>x.AdminStatus==true).ToList();
        }

        

        public bool Login(AdminLoginDto admin)
        {
            throw new NotImplementedException();
        }
    }
}

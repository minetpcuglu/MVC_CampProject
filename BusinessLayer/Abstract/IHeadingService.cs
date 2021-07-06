using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id); //sartlı listeleme yazara göre listele
        List<Heading> GetListByCategory(int id); //sartlı listeleme yazara göre listele
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);


        List<Heading> Get(int id);  //ödev 2
        List<Heading> CategoryNameWithMaximumTitles(); //ödev 2
    }
}

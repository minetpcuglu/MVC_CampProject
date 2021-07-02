using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList(); //yazarları listele 
       

        void writerAdd(Writer writer);
        void writerDelete(Writer writer);
        void writerUpdate(Writer writer);
        Writer GetById(int id);
    }
}

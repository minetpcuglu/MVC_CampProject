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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal; //istediğimiz interface ulasmak için 

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterID==id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
            //return _writerDal.List(x => x.UserName.Contains("a"));//sartlı listeleme
        }

        public void writerAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void writerDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

      
        public void writerUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}

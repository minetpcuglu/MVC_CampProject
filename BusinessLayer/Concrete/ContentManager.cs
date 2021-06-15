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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            throw new NotImplementedException();
        }

        public void DeleteContent(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetListHeadingID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListWriterID(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

       

        public void UpdateContent(Content content)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
           _headingDal = headingDal;
        }

        public List<Heading> CategoryNameWithMaximumTitles()
        {
            return _headingDal.List().GroupBy(x => x.CategoryID).Select(y => new Heading
            {
                CategoryID = y.LastOrDefault().CategoryID,
                Category = y.LastOrDefault().Category,
                contents = y.LastOrDefault().contents,
                HeadingDate = y.LastOrDefault().HeadingDate,
                HeadingID = y.LastOrDefault().HeadingID,
                HeadingName = y.LastOrDefault().HeadingName,
                Writer = y.LastOrDefault().Writer,
                WriterID = y.LastOrDefault().WriterID
            }).Take(1).OrderByDescending(o => o.CategoryID).ToList();
        }

        public List<Heading> Get(int id)
        {
            return _headingDal.List(x => x.CategoryID == id);
        }
    }
}

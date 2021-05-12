using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class Istatistik
    {

        public int TotalCategoryCount { get; set; }
        public int SoftwareHeaderCount { get; set; }
        public int WriterCount { get; set; }
        public int NumericalDifferances { get; set; }
        public string CategoryNameWithMaximumTitles { get; set; }
    }
}

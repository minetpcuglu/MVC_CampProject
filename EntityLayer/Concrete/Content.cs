using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Content
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public bool ContentStatus { get; set; }  //silme işlemi için aktiflik pasiflik 


        //contentin (yazar)kısmı      ilişkili veriler
        public int? WriterID { get; set; }  //soru işareti verilirse null degeri verildiği consoldaki hata kalkar hata nedeni birden fazla foreign key oldugundan 
        public virtual Writer Writer { get; set; }


        //contentin (baslıgı)         ilişkili veriler 
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }
    }
}

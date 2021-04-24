using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }


        //İlişkiler   1 baslık(heading) 1 categoride vardır 
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


        //1-1  bire cok    içerik baslık
        public ICollection<Content> contents { get; set; }


        //1-1 bire cok  writer heading (yazar baslık)
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}

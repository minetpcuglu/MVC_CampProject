using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public class Category
    {

        [Key]
        public int CategoryID { get; set; }

       [StringLength(50)]
        public string CategoryName { get; set; }

       [StringLength(200)]
        public string CategoryDescription { get; set; }

        //bool oldugu için kısıtlamaya gerek yok 
        public bool CategoryStatus { get; set; }  //ilişkili tablolarda silme işlemi yapılmayacak aktiflik veya pasiflik durumu etkinleştirilcek

        //lişkiler   1 kategoride birden fazla baslık vardır
        public ICollection<Heading> headings { get; set; } //heading ilişki kurulcak tablo 
    }
}

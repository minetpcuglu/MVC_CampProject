using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Ability
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public byte  Value { get; set; }
      
        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }  
        public string AdminPassword { get; set; }
        public bool AdminStatus { get; set; }
        //public string AdminRoleName { get; set; }
        public int? RoleId { get; set; }
        public virtual AdminRole AdminRole { get; set; }

    }

}

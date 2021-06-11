﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Writer
    {
        [Key]
        public int WriterID { get; set; }

       [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string WriterSurname { get; set; }

       [StringLength(250)]
        public string Image { get; set; }

       [StringLength(200)]
        public string WriterMail { get; set; }

        [StringLength(200)]
        public string WriterPassword { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(100)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; }





        //ilişkiler yazar içerik
        public ICollection<Content> contents { get; set; }


        //ilişki yazar baslık 
        public ICollection<Heading> headings { get; set; }
    }
}

﻿using System;
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
        public int CategoryId { get; set; }

        [StringLength(60)]
        public string CategoryName { get; set; }

        [StringLength(300)]
        public string CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; }
        
        
        [StringLength(15)]
        public string CategoryColor { get; set; }


        public ICollection<Heading> Headings { get; set; }
    }
}

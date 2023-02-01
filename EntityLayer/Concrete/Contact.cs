﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(60)]
        public string UserName { get; set; }

        [StringLength(70)]
        public string UserMail { get; set; }

        public DateTime date { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
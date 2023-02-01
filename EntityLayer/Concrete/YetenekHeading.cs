using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class YetenekHeading
    {
        [Key]
        public int YetenekHeadingId { get; set; }

        [StringLength(150)]
        public string YetenekHeadingTitleName { get; set; }

        [StringLength(150)]
        public string YetenekHeadingName { get; set; }

        [StringLength(150)]
        public string YetenekHeadingUnvan { get; set; }

        [StringLength(500)]
        public string YetenekHeadingImg { get; set; }
    }
}

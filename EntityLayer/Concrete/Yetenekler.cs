using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Yetenekler
    {

        [Key]
        public int YeteneklerId { get; set; }

        [StringLength(150)]
        public string YeteneklerName { get; set; }

        [StringLength(3)]
        public string YeteneklerValue { get; set; }
    }

}

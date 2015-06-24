using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
    public class Country : BaseClass
    {
        [Key]
        public int CountryId { get; set; }

        [Required]//check unique user name
        public string Name { get; set; }
    }
}

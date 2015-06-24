using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
  public  class State
    {
        [Key]
        public int StateId { get; set; }
      
        public int CountryId { get; set; }

      
        public string Name { get; set; }


        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
   public class ContactUsBM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}

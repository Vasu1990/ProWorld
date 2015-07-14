using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }

        [Required]//check unique user name
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
       
    }
}

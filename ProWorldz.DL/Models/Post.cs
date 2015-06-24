using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }
        [ForeignKey("User")]
        public int PostedBy { get; set; }

        public DateTime PostedDate { get; set; }

        public virtual User User { get; set; }
       
    }
}

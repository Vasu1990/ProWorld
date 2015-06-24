using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class UserPostComment:BaseClass
    {
        [Key]
        public int Id { get; set; }
       [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("UserPost")]
        public int PostId { get; set; }

        public string Comment { get; set; }

        public virtual User User { get; set; }

        public virtual UserPost UserPost { get; set; }
    }
}

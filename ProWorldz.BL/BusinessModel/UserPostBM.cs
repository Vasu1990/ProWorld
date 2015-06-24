using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProWorldz.BL.BusinessModel
{
   public class UserPostBM : BaseBM
    {
        
        public int Id { get; set; }

        public string UserName { get; set; }

        public int UserId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Post { get; set; }
    }
}

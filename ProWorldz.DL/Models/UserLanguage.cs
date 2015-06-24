using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class UserLanguage
    {
       [Key]
        public int Id { get; set; }
       public int UserId { get; set; }
       public string Language { get; set; }
       public string Level { get; set; }
    }
}

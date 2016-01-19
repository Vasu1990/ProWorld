using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class UserBlock : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int CurrentUserId { get; set; }

        public int ShareUserId { get; set; }

        public bool IsBlock { get; set; }

        public bool IsFollow { get; set; }

       


    }
}

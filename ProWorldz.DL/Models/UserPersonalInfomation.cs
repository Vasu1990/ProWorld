﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class UserPersonalInfomation:BaseClass
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]//check unique user name
        public int UserId { get; set; }

      

        public virtual User User { get; set; }
      
    }
}

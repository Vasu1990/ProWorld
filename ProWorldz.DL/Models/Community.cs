﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
    public class Community : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [Required]//check unique user name
        public string Name { get; set; }

        public int CountryId { get; set; }

        public int ParentId { get; set; }
    }
}

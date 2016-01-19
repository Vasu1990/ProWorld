using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
    public class ShareContactDetail : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int CurrentUserId { get; set; }

        public int ShareUserId { get; set; }

        public string Message { get; set; }

    }
}

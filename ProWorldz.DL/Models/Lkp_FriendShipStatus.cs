using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
    public class Lkp_FriendShipStatus
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; }
        
    }
}

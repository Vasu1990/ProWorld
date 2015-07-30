using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class Friend
    {
        [Key]
        public int Id { get; set; }

       
        public int UserId { get; set; }

        public int FriendId  { get; set; }

        public DateTime CreationDate { get; set; }

       [ForeignKey("Lkp_FriendShipStatus")]
        public int FriendShipStatusId { get; set; }

        public virtual User FriendUser { get; set; }
        public virtual Lkp_FriendShipStatus Lkp_FriendShipStatus { get; set; }
        
    }
}

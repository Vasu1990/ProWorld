using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
   public class FriendBM
    {
        
        public int Id { get; set; }
        
        public int UserId { get; set; }

        public int FriendId { get; set; }

        public DateTime CreationDate { get; set; }
        
        public int FriendShipStatusId { get; set; }

        public string FriendName { get; set; }
        
       public string FriendImage { get; set; }

       public int FriendCommunity { get; set; }

    }
}

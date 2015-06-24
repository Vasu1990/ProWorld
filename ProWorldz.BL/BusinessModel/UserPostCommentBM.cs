using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
    public class UserPostCommentBM:BaseBM
    {
        
        public int Id { get; set; }
        
        public int UserId { get; set; }

        
        public int PostId { get; set; }

        public string Comment { get; set; }

    }
}

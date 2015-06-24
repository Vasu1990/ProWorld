using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
    public class PostComment
    {
        [Key]
        public int Id { get; set; }

        public int PostedId { get; set; }

        public string Message { get; set; }

        [ForeignKey("User")]
        public int CommentedBy { get; set; }

        public DateTime CommentedDate { get; set; }


    }
}

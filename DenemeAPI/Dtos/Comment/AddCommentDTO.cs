using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class AddCommentDTO
    {
        public string CommentDescription { get; set; }
        public string CommentOwner { get; set; }
        public int HaberId { get; set; }
    }
}

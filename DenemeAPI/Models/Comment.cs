using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentOwner { get; set; }
        public string CommentDescription { get; set; }
        public bool IsConfirmed { get; set; }
        public int HaberId { get; set; }
        public Haber Haber { get; set; }
    }
}

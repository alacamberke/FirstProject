using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Haber
    {
        [Key]
        public int ID { get; set; }
        public string HaberName { get; set; }
        public string HaberDescription { get; set; }
        public string HaberOwner { get; set; }
        public bool Confirmation { get; set; }
        public Kategori kategori { get; set; }
        public int KategoriId { get; set; }
        public List<Comment> Comments { get; set; }

    }
}

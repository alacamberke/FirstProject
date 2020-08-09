using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriName { get; set; }
        public List<Haber> Habers { get; set; }
    }
}

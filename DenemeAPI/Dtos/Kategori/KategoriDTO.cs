using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Kategori
{
    public class KategoriDTO
    {
        public string KategoriName { get; set; }
        public List<Haber> Habers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Haber
    {
        public int HaberID { get; set; }
        public string HaberTitle { get; set; }
        public string HaberContent { get; set; }
        public string HaberOwner { get; set; }
        public string HaberSource { get; set; }
        public int KategoriId { get; set; }
    }
}

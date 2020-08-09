using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class AddHaberDTO
    {
        public string HaberName { get; set; }
        public string HaberDescription { get; set; }
        public string HaberOwner { get; set; }
        public int KategoriID { get; set; }
    }
}

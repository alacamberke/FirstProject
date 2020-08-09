using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class HaberDTO
    {
        [Required]
        public string HaberName { get; set; }

        [Required]
        public string HaberDescription { get; set; }

        [Required]
        public string HaberOwner { get; set; }

        [Required]
        public string KategoriName { get; set; }
    }
}

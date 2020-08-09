using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class LogClass
    {
        [Key]
        public int LogID { get; set; }
        public string LogCaption { get; set; }
        public string LogArgumentDetail { get; set; }
        public bool IsBefore { get; set; }
        public DateTime Date { get; set; }
    }
}
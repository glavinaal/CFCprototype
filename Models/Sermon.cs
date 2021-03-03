using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFCprototype.Models
{
    public class Sermon
    {
        public int SermonID { get; set; }
        public string SermonTitle { get; set; }
        public string SermonLink { get; set; }
        public DateTime SermonDate { get; set; }
    }
}

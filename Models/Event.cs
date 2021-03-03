using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFCprototype.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public Member EventHost { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
    }
}

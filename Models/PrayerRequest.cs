using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFCprototype.Models
{
    public class PrayerRequest
    {
        public int PrayerRequestID { get; set; }
        public Member RequestPoster { get; set; }
        public string RequestSubject { get; set; }
        public string RequestBody { get; set; }
        public DateTime RequestDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFCprototype.Models
{
    public class MembersClassifieds
    {
        public int MembersClassifiedsID { get; set; }
        public Member PosterName { get; set; }
        public string ClassifiedTitle { get; set; }
        public string ClassifiedBody { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime PostDuration { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFCprototype.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}

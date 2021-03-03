using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFCprototype.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public Member CommenterName { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}

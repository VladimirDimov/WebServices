using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class Dislike
    {
        public int DislikeId { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public abstract class Vote
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}

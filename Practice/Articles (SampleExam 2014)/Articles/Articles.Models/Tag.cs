namespace Articles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tag
    {
        private ICollection<Article> articles;

        public Tag()
        {
            this.articles = new HashSet<Article>();
        }

        public int TagId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }

            set
            {
                this.articles = value;
            }
        }
    }
}

namespace Articles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Category
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles = new HashSet<Article>();
        }

        public int CategoryId { get; set; }

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

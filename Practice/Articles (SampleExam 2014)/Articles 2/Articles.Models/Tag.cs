namespace Articles.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tag
    {
        private ICollection<Article> articles;

        public Tag()
        {
            this.articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}

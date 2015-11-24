namespace Articles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        private ICollection<Tag> tags;
        private ICollection<Like> likes;
        private ICollection<Dislike> dislikes;

        public Article()
        {
            this.tags = new HashSet<Tag>();
            this.likes = new HashSet<Like>();
            this.dislikes = new HashSet<Dislike>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<Dislike> Dislikes
        {
            get { return this.dislikes; }
            set { this.dislikes = value; }
        }
    }
}

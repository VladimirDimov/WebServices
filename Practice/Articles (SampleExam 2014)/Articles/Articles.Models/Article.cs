namespace Articles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        private ICollection<Tag> tags;
        private ICollection<Comment> comments;
        private ICollection<Like> likes;
        private ICollection<Dislike> dislikes;

        public Article()
        {
            this.tags = new HashSet<Tag>();
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<Like>();
            this.dislikes = new HashSet<Dislike>();
        }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Tag> Tags
        {
            get
            {
                return this.tags;
            }

            set
            {
                this.tags = value;
            }
        }

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }

            set
            {
                this.likes = value;
            }
        }

        public virtual ICollection<Dislike> Dislikes
        {
            get
            {
                return this.dislikes;
            }

            set
            {
                this.dislikes = value;
            }
        }
    }
}

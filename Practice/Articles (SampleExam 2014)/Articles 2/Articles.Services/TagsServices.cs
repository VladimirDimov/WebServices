using Articles.Data.Repositories;
using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Services
{
    public class TagsServices
    {
        private IRepository<Tag> tags;
        private IRepository<Article> articles;

        public TagsServices(IRepository<Tag> tags, IRepository<Article> articles)
        {
            this.tags = tags;
            this.articles = articles;
        }

        public Tag GetByName(string name)
        {
            var tag = this.tags.All()
                .FirstOrDefault(t => t.Name == name);

            return tag;
        }

        public ICollection<Tag> GetTagCollection(IEnumerable<string> tags)
        {
            var result = new List<Tag>();

            foreach (var tagName in tags)
            {
                var tagToAdd = this.GetByName(tagName);
                if (tagToAdd == null)
                {
                    tagToAdd = this.AddNewTag(tagName);
                }

                result.Add(tagToAdd);
            }

            return result;
        }

        public Tag AddNewTag(string name)
        {
            var tagToAdd = new Tag
            {
                Name = name
            };

            this.tags.Add(tagToAdd);
            this.tags.SaveChanges();

            return this.tags.GetById(tagToAdd.Id);
        }

        public IQueryable<Article> GetArticlesByTagId(int tagId)
        {
            if (!this.tags.All().Any(t => t.Id == tagId))
            {
                throw new ArgumentException("Invalid tag id!");
            }

            var articlesToReturn = this.articles.All()
                .Where(a => a.Tags.Any(t => t.Id == tagId))
                .OrderBy(a => a.DateCreated);

            return articlesToReturn;
        }
    }
}

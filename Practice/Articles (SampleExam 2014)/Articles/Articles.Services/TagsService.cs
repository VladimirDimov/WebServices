namespace Articles.Services
{
    using Articles.Data.Repository;
    using Articles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TagsService
    {
        private IRepository<Tag> tags;

        public TagsService(IRepository<Tag> tags)
        {
            this.tags = tags;
        }

        public ICollection<Tag> GetCollection(IEnumerable<string> tagNames)
        {
            var result = new HashSet<Tag>();

            foreach (var tag in tagNames)
            {
                var tagInDb = this.tags.All().FirstOrDefault(t => t.Name == tag);
                if (tagInDb == null)
                {
                    tagInDb = new Tag
                    {
                        Name = tag,
                    };

                    this.tags.Add(tagInDb);
                    this.tags.SaveChanges();
                }

                result.Add(tagInDb);
            }

            return result;
        }
    }
}

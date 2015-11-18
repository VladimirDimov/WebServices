namespace Articles.Services
{
    using Articles.Data.Repository;
    using Articles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoriesService
    {
        private IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public Category GetByName(string name)
        {
            var categoryToReturn = this.categories.All()
                .FirstOrDefault(c => c.Name == name);

            if (categoryToReturn == null)
            {
                throw new ArgumentException("Invalid category name!");
            }

            return categoryToReturn;
        }
    }
}

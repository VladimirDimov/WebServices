namespace Articles.Services
{
    using Articles.Data.Repositories;
    using Articles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoriesServices
    {
        private IRepository<Category> categories;

        public CategoriesServices(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public Category GetByName(string name)
        {
            var category = this.categories.All()
                .FirstOrDefault(c => c.Name == name);

            return category;
        }
    }
}

namespace ChatSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Articles.Models;

    public interface IArticlesDbContext
    {
        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();
    }
}

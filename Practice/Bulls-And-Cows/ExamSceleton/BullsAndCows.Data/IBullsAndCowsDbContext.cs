namespace BullsAndCows.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BullsAndCows.Models;

    public interface IBullsAndCowsDbContext
    {
        //IDbSet<ChatMessage> ChatMessages { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();
    }
}

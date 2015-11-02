namespace Artists.Data
{
    using Artists.Models;
    using System.Data.Entity;

    public class ArtistsDbContext : DbContext
    {
        public ArtistsDbContext()
            : base("Artists")
        {
        }

        public virtual IDbSet<Artist> Artists { get; set; }
        public virtual IDbSet<Country> Countries { get; set; }
        public virtual IDbSet<Album> Albums { get; set; }
        public virtual IDbSet<Producer> Producers { get; set; }
        public virtual IDbSet<Song> Songs { get; set; }
    }
}

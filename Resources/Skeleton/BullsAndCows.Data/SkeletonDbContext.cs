namespace BullsAndCows.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class SkeletonDbContext : IdentityDbContext<User>
    {
        public SkeletonDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Guess> Guesses { get; set; }

        public static SkeletonDbContext Create()
        {
            return new SkeletonDbContext();
        }
    }
}

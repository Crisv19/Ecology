using Ecology.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecology.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext>options) : base(options) { }


        public DbSet<Material>Materials { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Material>().HasIndex(c => c.Name).IsUnique();

        }

    }

}
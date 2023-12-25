using Microsoft.EntityFrameworkCore;
using MyBiz.Configurations;
using MyBiz.Entities;

namespace MyBiz.DAL
{
    public class AppDbContext:DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkerConfiguration).Assembly);
           base.OnModelCreating( modelBuilder);
        }
    }
}

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

        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                var entity = item.Entity;
                switch (item.State)
                {
                    case EntityState.Deleted:
                        entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Modified:
                        entity.UpdateDate = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Added:
                        entity.CreateDate = DateTime.UtcNow.AddHours(4);
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}

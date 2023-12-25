using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBiz.Entities;

namespace MyBiz.Configurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.About)
               .IsRequired()              
               .HasMaxLength(200);            
            builder.Property(x => x.ImageUrl)
               .IsRequired();
            builder.Property(x => x.TwitUrl)
                .IsRequired();
            builder.Property(x => x.FaceUrl)
               .IsRequired();              
            builder.Property(x => x.LinkedinUrl)
               .IsRequired();
            builder.Property(x => x.InstaUrl)
               .IsRequired();


        }
    }
}

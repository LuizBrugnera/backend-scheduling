using BackendSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSchedule.Infrastructure.EntitiesConfiguration
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.Price);

            builder.HasOne(w => w.Professional)
                   .WithMany(p => p.WorkList)
                   .HasForeignKey(w => w.ProfessionalId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
              new Work(1, "Corte de Cabelo", new Professional(1, "Jhon Carlos", "jhon@gmail.com", "jhon123", "54996054176"), TimeSpan.FromHours(1), 25.0),
              new Work(2, "Massagem", new Professional(1, "Jhon Carlos", "jhon@gmail.com", "jhon123", "54996054176"), TimeSpan.FromHours(1.5), 50.0),
              new Work(3, "Manicure", new Professional(3, "Amado Batista", "batista@gmail.com", "batista123", "21948212432"), TimeSpan.FromMinutes(30), 20.0)
            );
        }
    }
}


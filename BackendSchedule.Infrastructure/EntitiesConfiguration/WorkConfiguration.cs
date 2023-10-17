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
              new
              {
                  Id = 1,
                  Name = "Corte de Cabelo",
                  ProfessionalId = 1,
                  Duration = new TimeSpan(1, 0, 0),
                  Price = 25.0
              },
              new
              {
                  Id = 2,
                  Name = "Massagem",
                  ProfessionalId = 1,
                  Duration = new TimeSpan(1, 30, 0),
                  Price = 50.0
              },
              new
              {
                  Id = 3,
                  Name = "Manicure",
                  ProfessionalId = 3,
                  Duration = new TimeSpan(0, 30, 0)
              }
            );
        }
    }
}


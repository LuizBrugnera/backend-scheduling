using BackendSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSchedule.Infrastructure.EntitiesConfiguration
{
    public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(11).IsRequired();

            builder.HasMany(p => p.SchedulingList)
                   .WithOne(s => s.Professional)
                   .HasForeignKey(s => s.ProfessionalId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(p => p.WorkList)
                   .WithOne(w => w.Professional)
                   .HasForeignKey(w => w.ProfessionalId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
              new
              {
                  Id = 1,
                  Name = "Jhon Carlos",
                  Email = "jhon@gmail.com",
                  Password = "jhon123",
                  Phone = "54996054176"
              },
              new
              {
                  Id = 2,
                  Name = "Ze Da Manga",
                  Email = "damanga@gmail.com",
                  Password = "damanga123",
                  Phone = "54943022176"
              },
              new
              {
                  Id = 3,
                  Name = "Amado Batista",
                  Email = "batista@gmail.com",
                  Password = "batista123",
                  Phone = "21948212432"
              }
            );
        }
    }
}


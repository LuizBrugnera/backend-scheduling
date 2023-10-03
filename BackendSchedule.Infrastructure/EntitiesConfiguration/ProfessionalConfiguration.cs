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
              new Professional(1, "Jhon Carlos", "jhon@gmail.com", "jhon123", "54996054176"),
              new Professional(2, "Ze Da Manga", "damanga@gmail.com", "damanga123", "54943022176"),
              new Professional(3, "Amado Batista", "batista@gmail.com", "batista123", "21948212432")
            );
        }
    }
}


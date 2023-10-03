using BackendSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSchedule.Infrastructure.EntitiesConfiguration
{
    public class SchedulingConfiguration : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Professional)
                   .WithMany(p => p.SchedulingList)
                   .HasForeignKey(s => s.ProfessionalId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.AppointmentList)
                   .WithOne(a => a.Scheduling)
                   .HasForeignKey(a => a.SchedulingId);

            builder.OwnsOne(s => s.TimePeriods, tp =>
            {
                tp.Property(t => t.StartMorning);
                tp.Property(t => t.EndMorning);
                tp.Property(t => t.StartAfternoon);
                tp.Property(t => t.EndAfternoon);
                tp.Property(t => t.StartNight);
                tp.Property(t => t.EndNight);
            });
            builder.Property(s => s.WorkDay).IsRequired();

            // Dados iniciais
            builder.HasData(
                new Scheduling(new Professional(1, "Jhon Carlos", "jhon@gmail.com", "jhon123", "54996054176"),
                new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0), null, null, null, null, true)
            );
        }
    }
}

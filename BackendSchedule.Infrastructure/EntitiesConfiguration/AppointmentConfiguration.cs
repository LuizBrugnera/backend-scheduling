using BackendSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSchedule.Infrastructure.EntitiesConfiguration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.StartTime).IsRequired();
            builder.Property(a => a.EndTime).IsRequired();

            builder.HasOne(a => a.Scheduling)
                   .WithMany(s => s.AppointmentList)
                   .HasForeignKey(a => a.SchedulingId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Work)
                   .WithMany()
                   .HasForeignKey(a => a.WorkId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(a => a.Customer, customer =>
            {
                customer.Property(c => c.Name).HasColumnName("CustomerName").IsRequired();
                customer.Property(c => c.Phone).HasColumnName("CustomerPhone").IsRequired();
                customer.Property(c => c.Email).HasColumnName("CustomerEmail");
            });

            builder.HasData(
                new Appointment(1, new Scheduling(new Professional(1, "Jhon Carlos", "jhon@gmail.com", "jhon123", "54996054176"),
                new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0), null, null, null, null, true),
                new Work("Corte de Cabelo", new Professional(1, "Jhon Carlos", "jhon@gmail.com", "jhon123", "54996054176"), TimeSpan.FromHours(1), 25.0),
                new TimeSpan(10, 30, 0),
                "Jane Doe", "jane@gmail.com", "54996054179")
            );
        }
    }
}

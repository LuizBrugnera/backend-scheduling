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
                new
                {
                    Id = 1,
                    StartTime = new TimeSpan(10, 30, 0),
                    EndTime = new TimeSpan(11, 30, 0),
                    SchedulingId = 1,
                    WorkId = 1,
                    Customer_Name = "Jane Doe",
                    Customer_Email = "jane@gmail.com",
                    Customer_Phone = "54996054179"
                }
            );
        }
    }
}

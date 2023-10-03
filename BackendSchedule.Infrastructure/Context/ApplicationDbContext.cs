using BackendSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace BackendSchedule.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Scheduling> Scheduling { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Work> Work { get; set; }
        public DbSet<Professional> Professional { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
                .Assembly);
        }
    }
}

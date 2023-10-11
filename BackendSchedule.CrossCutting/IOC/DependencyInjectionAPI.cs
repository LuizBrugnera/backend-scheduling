using BackendSchedule.Application.Interfaces;
using BackendSchedule.Application.Mappings;
using BackendSchedule.Application.Services;
using BackendSchedule.Domain.Interfaces;
using BackendSchedule.Infrastructure.Context;
using BackendSchedule.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackendSchedule.CrossCutting.IOC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<IWorkRepository, WorkRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
            services.AddScoped<ISchedulingService, SchedulingService>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IProfessionalService, ProfessionalService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}

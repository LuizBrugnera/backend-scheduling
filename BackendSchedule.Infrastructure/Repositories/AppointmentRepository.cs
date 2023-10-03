using BackendSchedule.Domain.Entities;
using BackendSchedule.Domain.Interfaces;
using BackendSchedule.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendSchedule.Infrastructure.Repositories
{
    internal class AppointmentRepository : IAppointmentRepository
    {
        private ApplicationDbContext _appointmentContext;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _appointmentContext = context;
        }
        public async Task<IEnumerable<Appointment>> GetAll()
        {
            try
            {
                var appointment = await _appointmentContext.Appointment.ToListAsync();
                return appointment;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                var erro2 = ex.InnerException;
                var erro3 = ex.StackTrace;
                Console.WriteLine(erro, erro2, erro3);
                throw;
            }
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _appointmentContext.Appointment.FindAsync(id);
        }
        public async Task<Appointment> Create(Appointment appointment)
        {
            _appointmentContext.Add(appointment);
            await _appointmentContext.SaveChangesAsync();
            return appointment;
        }
        public async Task<Appointment> Update(Appointment appointment)
        {
            _appointmentContext.Update(appointment);
            await _appointmentContext.SaveChangesAsync();
            return appointment;
        }
        public async Task<Appointment> Delete(Appointment appointment)
        {
            _appointmentContext.Remove(appointment);
            await _appointmentContext.SaveChangesAsync();
            return appointment;
        }
    }
}

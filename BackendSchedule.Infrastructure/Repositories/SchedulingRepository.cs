using BackendSchedule.Domain.Entities;
using BackendSchedule.Domain.Interfaces;
using BackendSchedule.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendSchedule.Infrastructure.Repositories
{
    internal class SchedulingRepository : ISchedulingRepository
    {
        private ApplicationDbContext _schedulingContext;

        public SchedulingRepository(ApplicationDbContext context)
        {
            _schedulingContext = context;
        }
        public async Task<IEnumerable<Scheduling>> GetAll()
        {
            try
            {
                var scheduling = await _schedulingContext.Scheduling.ToListAsync();
                return scheduling;
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

        public async Task<Scheduling> GetById(int id)
        {
            return await _schedulingContext.Scheduling.FindAsync(id);
        }
        public async Task<Scheduling> Create(Scheduling scheduling)
        {
            _schedulingContext.Add(scheduling);
            await _schedulingContext.SaveChangesAsync();
            return scheduling;
        }
        public async Task<Scheduling> Update(Scheduling scheduling)
        {
            _schedulingContext.Update(scheduling);
            await _schedulingContext.SaveChangesAsync();
            return scheduling;
        }
        public async Task<Scheduling> Delete(Scheduling scheduling)
        {
            _schedulingContext.Remove(scheduling);
            await _schedulingContext.SaveChangesAsync();
            return scheduling;
        }
    }
}

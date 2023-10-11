using BackendSchedule.Domain.Entities;
using BackendSchedule.Domain.Interfaces;
using BackendSchedule.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace BackendSchedule.Infrastructure.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private ApplicationDbContext _workContext;

        public WorkRepository(ApplicationDbContext context)
        {
            _workContext = context;
        }
        public async Task<IEnumerable<Work>> GetAll()
        {
            try
            {
                var work = await _workContext.Work.ToListAsync();
                return work;
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
        public async Task<Work> GetById(int id)
        {
            return await _workContext.Work.FindAsync(id);
        }
        public async Task<Work> Create(Work work)
        {
            _workContext.Add(work);
            await _workContext.SaveChangesAsync();
            return work;
        }
        public async Task<Work> Update(Work work)
        {
            _workContext.Update(work);
            await _workContext.SaveChangesAsync();
            return work;
        }
        public async Task<Work> Delete(Work work)
        {
            _workContext.Remove(work);
            await _workContext.SaveChangesAsync();
            return work;
        }
    }
}

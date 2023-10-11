using BackendSchedule.Domain.Entities;
using BackendSchedule.Domain.Interfaces;
using BackendSchedule.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendSchedule.Infrastructure.Repositories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private ApplicationDbContext _professionalContext;

        public ProfessionalRepository(ApplicationDbContext context)
        {
            _professionalContext = context;
        }
        public async Task<IEnumerable<Professional>> GetAll()
        {
            try
            {
                var professional = await _professionalContext.Professional.ToListAsync();
                return professional;
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

        public async Task<Professional> GetById(int id)
        {
            return await _professionalContext.Professional.FindAsync(id);
        }
        public async Task<Professional> Create(Professional professional)
        {
            _professionalContext.Add(professional);
            await _professionalContext.SaveChangesAsync();
            return professional;
        }
        public async Task<Professional> Update(Professional professional)
        {
            _professionalContext.Update(professional);
            await _professionalContext.SaveChangesAsync();
            return professional;
        }
        public async Task<Professional> Delete(Professional professional)
        {
            _professionalContext.Remove(professional);
            await _professionalContext.SaveChangesAsync();
            return professional;
        }
    }
}

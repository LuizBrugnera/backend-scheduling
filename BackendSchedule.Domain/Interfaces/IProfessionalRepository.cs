using BackendSchedule.Domain.Entities;

namespace BackendSchedule.Domain.Interfaces
{
    public interface IProfessionalRepository
    {
        Task<IEnumerable<Professional>> GetAll();
        Task<Professional> GetById(int id);
        Task<Professional> Create(Professional Professional);
        Task<Professional> Update(Professional Professional);
        Task<Professional> Delete(Professional Professional);
    }
}

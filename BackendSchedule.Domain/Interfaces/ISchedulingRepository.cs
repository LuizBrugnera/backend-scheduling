using BackendSchedule.Domain.Entities;

namespace BackendSchedule.Domain.Interfaces
{
    public interface ISchedulingRepository
    {
        Task<IEnumerable<Scheduling>> GetAll();
        Task<Scheduling> GetById(int id);
        Task<Scheduling> Create(Scheduling Scheduling);
        Task<Scheduling> Update(Scheduling Scheduling);
        Task<Scheduling> DeleteById(int id);
    }
}

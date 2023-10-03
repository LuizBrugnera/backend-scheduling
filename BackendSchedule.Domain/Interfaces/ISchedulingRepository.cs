using BackendSchedule.Domain.Entities;

namespace BackendSchedule.Domain.Interfaces
{
    public interface ISchedulingRepository
    {
        Task<IEnumerable<Scheduling>> GetAll();
        Task<Scheduling> GetById(int id);
        Task<Scheduling> Create(Scheduling scheduling);
        Task<Scheduling> Update(Scheduling scheduling);
        Task<Scheduling> Delete(Scheduling scheduling);
    }
}

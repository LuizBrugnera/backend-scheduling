using BackendSchedule.Domain.Entities;

namespace BackendSchedule.Domain.Interfaces
{
    public interface IWorkRepository
    {
        Task<IEnumerable<Work>> GetAll();
        Task<Work> GetById(int id);
        Task<Work> Create(Work work);
        Task<Work> Update(Work work);
        Task<Work> Delete(Work work);
    }
}

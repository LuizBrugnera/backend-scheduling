using BackendSchedule.Domain.Entities;

namespace BackendSchedule.Domain.Interfaces
{
    public interface IWorkRepository
    {
        Task<IEnumerable<Work>> GetAll();
        Task<Work> GetById(int id);
        Task<Work> Create(Work Work);
        Task<Work> Update(Work Work);
        Task<Work> DeleteById(int id);
    }
}

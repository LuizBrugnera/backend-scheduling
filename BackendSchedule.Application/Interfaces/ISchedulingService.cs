using BackendSchedule.Application.DTOs;

namespace BackendSchedule.Application.Interfaces
{
    public interface ISchedulingService
    {
        Task<IEnumerable<SchedulingDTO>> GetAll();
        Task<SchedulingDTO> GetById(int id);
        Task Create(SchedulingDTO schedulingDTO);
        Task Update(SchedulingDTO schedulingDTO);
        Task Delete(int id);
    }
}

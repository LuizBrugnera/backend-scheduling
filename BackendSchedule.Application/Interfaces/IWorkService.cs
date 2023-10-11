using BackendSchedule.Application.DTOs;

namespace BackendSchedule.Application.Interfaces
{
    public interface IWorkService
    {
        Task<IEnumerable<WorkDTO>> GetAll();
        Task<WorkDTO> GetById(int id);
        Task Create(WorkDTO workDTO);
        Task Update(WorkDTO workDTO);
        Task Delete(int id);
    }
}

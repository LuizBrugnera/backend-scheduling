using BackendSchedule.Application.DTOs;

namespace BackendSchedule.Application.Interfaces
{
    public interface IProfessionalService
    {
        Task<IEnumerable<ProfessionalDTO>> GetAll();
        Task<ProfessionalDTO> GetById(int id);
        Task Create(ProfessionalDTO professionalDTO);
        Task Update(ProfessionalDTO professionalDTO);
        Task Delete(int id);
    }
}

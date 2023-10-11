using BackendSchedule.Application.DTOs;
namespace BackendSchedule.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAll();
        Task<AppointmentDTO> GetById(int id);
        Task Create(AppointmentDTO appointmentDTO);
        Task Update(AppointmentDTO appointmentDTO);
        Task Delete(int id);
    }
}

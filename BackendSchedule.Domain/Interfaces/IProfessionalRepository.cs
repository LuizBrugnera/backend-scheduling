using BackendSchedule.Domain.Entities;

namespace BackendSchedule.Domain.Interfaces
{
    public interface IProfessionalRepository
    {
        Task<IEnumerable<Appointment>> GetAll();
        Task<Appointment> GetById(int id);
        Task<Appointment> Create(Appointment appointment);
        Task<Appointment> Update(Appointment appointment);
        Task<Appointment> DeleteById(int id);
    }
}

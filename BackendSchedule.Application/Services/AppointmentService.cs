using AutoMapper;
using BackendSchedule.Application.DTOs;
using BackendSchedule.Application.Interfaces;
using BackendSchedule.Domain.Entities;
using BackendSchedule.Domain.Interfaces;

namespace BackendSchedule.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAll()
        {
            try
            {
                var appointmentsEntity = await _appointmentRepository.GetAll();
                var appointmentsDTO = _mapper.Map<IEnumerable<AppointmentDTO>>(appointmentsEntity);
                return appointmentsDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<AppointmentDTO> GetById(int id)
        {
            try
            {
                var appointmentEntity = await _appointmentRepository.GetById(id);
                return _mapper.Map<AppointmentDTO>(appointmentEntity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Create(AppointmentDTO appointmentDTO)
        {
            try
            {
                var appointmentEntity = _mapper.Map<Appointment>(appointmentDTO);
                await _appointmentRepository.Create(appointmentEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(AppointmentDTO appointmentDTO)
        {
            try
            {
                var appointmentEntity = _mapper.Map<Appointment>(appointmentDTO);
                await _appointmentRepository.Update(appointmentEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var appointmentEntity = _appointmentRepository.GetById(id).Result;
                await _appointmentRepository.Delete(appointmentEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using AutoMapper;
using BackendSchedule.Application.DTOs;
using BackendSchedule.Application.Interfaces;
using BackendSchedule.Domain.Entities;
using BackendSchedule.Domain.Interfaces;

namespace BackendSchedule.Application.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly IMapper _mapper;
        public SchedulingService(ISchedulingRepository schedulingRepository, IMapper mapper)
        {
            _schedulingRepository = schedulingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SchedulingDTO>> GetAll()
        {
            try
            {
                var schedulingsEntity = await _schedulingRepository.GetAll();
                var schedulingsDTO = _mapper.Map<IEnumerable<SchedulingDTO>>(schedulingsEntity);
                return schedulingsDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SchedulingDTO> GetById(int id)
        {
            try
            {
                var schedulingEntity = await _schedulingRepository.GetById(id);
                return _mapper.Map<SchedulingDTO>(schedulingEntity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Create(SchedulingDTO schedulingDTO)
        {
            try
            {
                var schedulingEntity = _mapper.Map<Scheduling>(schedulingDTO);
                await _schedulingRepository.Create(schedulingEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(SchedulingDTO schedulingDTO)
        {
            try
            {
                var schedulingEntity = _mapper.Map<Scheduling>(schedulingDTO);
                await _schedulingRepository.Update(schedulingEntity);
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
                var schedulingEntity = _schedulingRepository.GetById(id).Result;
                await _schedulingRepository.Delete(schedulingEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

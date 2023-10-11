using AutoMapper;
using BackendSchedule.Application.DTOs;
using BackendSchedule.Application.Interfaces;
using BackendSchedule.Domain.Entities;
using BackendSchedule.Domain.Interfaces;

namespace BackendSchedule.Application.Services
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;
        private readonly IMapper _mapper;
        public WorkService(IWorkRepository workRepository, IMapper mapper)
        {
            _workRepository = workRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkDTO>> GetAll()
        {
            try
            {
                var worksEntity = await _workRepository.GetAll();
                var worksDTO = _mapper.Map<IEnumerable<WorkDTO>>(worksEntity);
                return worksDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<WorkDTO> GetById(int id)
        {
            try
            {
                var workEntity = await _workRepository.GetById(id);
                return _mapper.Map<WorkDTO>(workEntity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Create(WorkDTO workDTO)
        {
            try
            {
                var workEntity = _mapper.Map<Work>(workDTO);
                await _workRepository.Create(workEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(WorkDTO workDTO)
        {
            try
            {
                var workEntity = _mapper.Map<Work>(workDTO);
                await _workRepository.Update(workEntity);
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
                var workEntity = _workRepository.GetById(id).Result;
                await _workRepository.Delete(workEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

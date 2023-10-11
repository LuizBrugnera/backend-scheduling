using AutoMapper;
using BackendSchedule.Application.DTOs;
using BackendSchedule.Domain.Entities;
using BackendSchedule.Domain.Interfaces;

namespace BackendSchedule.Application.Services
{
    public class ProfessionalService
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly IMapper _mapper;
        public ProfessionalService(IProfessionalRepository professionalRepository, IMapper mapper)
        {
            _professionalRepository = professionalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfessionalDTO>> GetAll()
        {
            try
            {
                var professionalsEntity = await _professionalRepository.GetAll();
                var professionalsDTO = _mapper.Map<IEnumerable<ProfessionalDTO>>(professionalsEntity);
                return professionalsDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProfessionalDTO> GetById(int id)
        {
            try
            {
                var professionalEntity = await _professionalRepository.GetById(id);
                return _mapper.Map<ProfessionalDTO>(professionalEntity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Create(ProfessionalDTO professionalDTO)
        {
            try
            {
                var professionalEntity = _mapper.Map<Professional>(professionalDTO);
                await _professionalRepository.Create(professionalEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(ProfessionalDTO professionalDTO)
        {
            try
            {
                var professionalEntity = _mapper.Map<Professional>(professionalDTO);
                await _professionalRepository.Update(professionalEntity);
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
                var professionalEntity = _professionalRepository.GetById(id).Result;
                await _professionalRepository.Delete(professionalEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

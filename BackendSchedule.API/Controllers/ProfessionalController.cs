using BackendSchedule.Application.DTOs;
using BackendSchedule.Application.Interfaces;
using BackendSchedule.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendSchedule.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IProfessionalService _professionalService;
        public ProfessionalController(IProfessionalService professionalService)
        {
            _professionalService = professionalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionalDTO>>> Get()
        {
            try
            {
                var professionals = await _professionalService.GetAll();
                return Ok(professionals);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}", Name = "GetProfessional")]
        public async Task<ActionResult<Professional>> Get(int id)
        {
            try
            {
                var professional = await _professionalService.GetById(id);

                if (professional == null)
                    return NotFound();

                return Ok(professional);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfessionalDTO professionalDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _professionalService.Create(professionalDTO);

                return new CreatedAtRouteResult("GetProfessional",
                new { id = professionalDTO.Id }, professionalDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProfessionalDTO professionalDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != professionalDTO.Id)
                    return BadRequest();

                await _professionalService.Update(professionalDTO);

                return Ok(professionalDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Professional>> Delete(int id)
        {
            try
            {
                var professional = await _professionalService.GetById(id);

                if (professional == null)
                    return NotFound();

                await _professionalService.Delete(id);

                return Ok(professional);
            }
            catch
            {
                throw;
            }
        }

    }
}

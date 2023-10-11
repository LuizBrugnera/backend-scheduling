using BackendSchedule.Application.DTOs;
using BackendSchedule.Application.Interfaces;
using BackendSchedule.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendSchedule.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _workService;
        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkDTO>>> Get()
        {
            try
            {
                var works = await _workService.GetAll();
                return Ok(works);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}", Name = "GetWork")]
        public async Task<ActionResult<Work>> Get(int id)
        {
            try
            {
                var work = await _workService.GetById(id);

                if (work == null)
                    return NotFound();

                return Ok(work);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WorkDTO workDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _workService.Create(workDTO);

                return new CreatedAtRouteResult("GetWork",
                new { id = workDTO.Id }, workDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] WorkDTO workDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != workDTO.Id)
                    return BadRequest();

                await _workService.Update(workDTO);

                return Ok(workDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Work>> Delete(int id)
        {
            try
            {
                var work = await _workService.GetById(id);

                if (work == null)
                    return NotFound();

                await _workService.Delete(id);

                return Ok(work);
            }
            catch
            {
                throw;
            }
        }

    }
}

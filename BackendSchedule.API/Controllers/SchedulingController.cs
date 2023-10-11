using BackendSchedule.Application.DTOs;
using BackendSchedule.Application.Interfaces;
using BackendSchedule.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendSchedule.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;
        public SchedulingController(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchedulingDTO>>> Get()
        {
            try
            {
                var schedulings = await _schedulingService.GetAll();
                return Ok(schedulings);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}", Name = "GetScheduling")]
        public async Task<ActionResult<Scheduling>> Get(int id)
        {
            try
            {
                var scheduling = await _schedulingService.GetById(id);

                if (scheduling == null)
                    return NotFound();

                return Ok(scheduling);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SchedulingDTO schedulingDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _schedulingService.Create(schedulingDTO);

                return new CreatedAtRouteResult("GetScheduling",
                new { id = schedulingDTO.Id }, schedulingDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SchedulingDTO schedulingDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != schedulingDTO.Id)
                    return BadRequest();

                await _schedulingService.Update(schedulingDTO);

                return Ok(schedulingDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Scheduling>> Delete(int id)
        {
            try
            {
                var scheduling = await _schedulingService.GetById(id);

                if (scheduling == null)
                    return NotFound();

                await _schedulingService.Delete(id);

                return Ok(scheduling);
            }
            catch
            {
                throw;
            }
        }

    }
}

using BackendSchedule.Application.DTOs;
using BackendSchedule.Application.Interfaces;
using BackendSchedule.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendSchedule.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> Get()
        {
            try
            {
                var appointments = await _appointmentService.GetAll();
                return Ok(appointments);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}", Name = "GetAppointment")]
        public async Task<ActionResult<Appointment>> Get(int id)
        {
            try
            {
                var appointment = await _appointmentService.GetById(id);

                if (appointment == null)
                    return NotFound();

                return Ok(appointment);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppointmentDTO appointmentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _appointmentService.Create(appointmentDTO);

                return new CreatedAtRouteResult("GetAppointment",
                new { id = appointmentDTO.Id }, appointmentDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AppointmentDTO appointmentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != appointmentDTO.Id)
                    return BadRequest();

                await _appointmentService.Update(appointmentDTO);

                return Ok(appointmentDTO);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> Delete(int id)
        {
            try
            {
                var appointment = await _appointmentService.GetById(id);

                if (appointment == null)
                    return NotFound();

                await _appointmentService.Delete(id);

                return Ok(appointment);
            }
            catch
            {
                throw;
            }
        }

    }
}

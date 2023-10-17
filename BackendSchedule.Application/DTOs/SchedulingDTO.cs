using System.ComponentModel.DataAnnotations;

namespace BackendSchedule.Application.DTOs
{
    public class SchedulingDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Enter the professional's ID")]
        public int ProfessionalId { get; set; }
        public TimeSpan? StartMorning { get; set; }
        public TimeSpan? EndMorning { get; set; }
        public TimeSpan? StartAfternoon { get; set; }
        public TimeSpan? EndAfternoon { get; set; }
        public TimeSpan? StartNight { get; set; }
        public TimeSpan? EndNight { get; set; }
        [Required(ErrorMessage = "Let us know if it is a business day")]
        public bool WorkDay { get; set; }

        [Required(ErrorMessage = "Enter the day of the appointment")]
        public DateTime Day { get; set; }

        public List<AppointmentDTO> AppointmentList { get; set; } = new List<AppointmentDTO>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace BackendSchedule.Application.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the appointment ID")]
        public int SchedulingId { get; set; }

        [Required(ErrorMessage = "Enter the Work ID")]
        public int WorkId { get; set; }

        [Required(ErrorMessage = "Enter the Customer's Name")]
        [StringLength(100)]
        public string? CustomerName { get; set; }

        [EmailAddress(ErrorMessage = "It is not a valid email")]
        public string? CustomerEmail { get; set; }

        [Required(ErrorMessage = "Provide the telephone number")]
        [Phone(ErrorMessage = "Please provide a valid phone number")]
        public string? CustomerPhone { get; set; }

        [Required(ErrorMessage = "Enter the start time")]
        public TimeSpan StartTime { get; set; }
    }
}

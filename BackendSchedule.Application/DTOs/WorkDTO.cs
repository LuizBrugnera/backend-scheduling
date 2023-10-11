using System.ComponentModel.DataAnnotations;

namespace BackendSchedule.Application.DTOs
{
    public class WorkDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name length can't be more than 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Professional Id is required.")]
        public int ProfessionalId { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        public TimeSpan Duration { get; set; }

        public double? Price { get; set; }
    }
}

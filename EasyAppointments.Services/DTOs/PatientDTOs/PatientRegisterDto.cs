using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.PatientDTOs
{
    public record PatientRegisterDto
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string PatientName { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public string Contact { get; set; } = default!;
        
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; } = default!;

        public Role Role { get; set; }
    }
}

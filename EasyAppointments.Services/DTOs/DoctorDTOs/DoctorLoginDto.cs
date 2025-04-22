using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.DoctorDTOs
{
    public record DoctorLoginDto
    {
        [Required(ErrorMessage = "Required")]
        public string Identifier { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; } = default!;
    }
}

using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.DoctorDTOs
{
    public record DoctorRegisterDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string ConfirmPassword { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        [MaxLength(11)]
        public string Contact { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; } = default!;
        public Role Role { get; set; }
    }
}

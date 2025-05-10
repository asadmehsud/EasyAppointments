using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.AdminDTOs
{
    public record AdminRegisterDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public string Email { get; set; } = default!;
        
        [Required(ErrorMessage = "Required")]
        public string Contact { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; } = default!;
        public Role Role { get; set; } = default!;
    }
}

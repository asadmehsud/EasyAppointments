using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAppointments.Services.DTOs.AdminDTOs
{
    public record UpdateAdminDto
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
        [MaxLength(11)]
        public string Contact { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public string Address { get; set; } = default!;

        [Required(ErrorMessage = "Required")]
        public byte[] Image { get; set; } = Array.Empty<byte>();

        [Required(ErrorMessage = "Required")]
        public int? Status { get; set; }
        public string OTP { get; set; }
    }
}

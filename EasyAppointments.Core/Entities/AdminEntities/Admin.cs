using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.AdminEntities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Contact { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Address { get; set; }
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public int Status { get; set; }
        public string? OTP { get; set; }
        public Role Role{ get; set; }

    }
}

using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.PatientEntities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; } = default!;
        public string Contact { get; set; } = default!;
        public string? Email { get; set; }
        public string Password { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string Address { get; set; } = default!;
        public Role Role { get; set; } = default!;
    }
}

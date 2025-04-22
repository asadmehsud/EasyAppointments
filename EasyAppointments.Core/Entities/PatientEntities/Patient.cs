using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.PatientEntities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Contact { get; set; } 
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; } 
        public string? Address { get; set; }
        public Role Role { get; set; } 
    }
}

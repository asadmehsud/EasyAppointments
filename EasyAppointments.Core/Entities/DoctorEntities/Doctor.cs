using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.DoctorEntities
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Contact { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string CNIC { get; set; } = default!;
        public string? Address { get; set; }
        public byte[] Qualifications { get; set; } = Array.Empty<byte>();
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public int Status { get; set; }
        public int Province { get; set; }
        public int City { get; set; }
        public string? ZipCode { get; set; }
        public int Speciality { get; set; }
        public int ActiveStatus { get; set; }
        public Role Role { get; set; }
    }
}

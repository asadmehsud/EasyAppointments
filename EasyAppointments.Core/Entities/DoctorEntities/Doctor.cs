using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.DoctorEntities
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? CNIC { get; set; }
        public string? Address { get; set; }
        public string? AcademicQualifications { get; set; }
        public byte[]? QualificationDocuments { get; set; }
        public byte[]? Image { get; set; }
        public byte[]? CNICFrontImage { get; set; }
        public int Status { get; set; }
        public string? ZipCode { get; set; }
        public int Speciality { get; set; }
        public int ActiveStatus { get; set; }
        public string? OTP { get; set; }
        public Role Role { get; set; }
    }
}

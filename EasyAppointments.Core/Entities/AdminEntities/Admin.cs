using EasyAppointments.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.AdminEntities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Contact { get; set; } 
        public string?  Email { get; set; } 
        public string? Address { get; set; }
        public byte[]? Image { get; set; }
        public int Status { get; set; }
        public string? OTP { get; set; }
        public Role Role{ get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.AdminEntities
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } 
        public int Status { get; set; }
    }
}

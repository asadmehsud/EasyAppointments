using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.AdminEntities
{
    public class Day
    {
        [Key]
        public int Id { get; set; }
        public string? WeekDay { get; set; } 
    }
}

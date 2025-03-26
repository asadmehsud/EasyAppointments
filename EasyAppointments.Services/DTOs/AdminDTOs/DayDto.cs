using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.AdminDTOs
{
    public class DayDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string WeekDay { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.AdminDTOs
{
    public class TimeDto
    {
        public int Id { get; set; }
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Required")]
        public string From { get; set; } = default!;
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Required")]
        public string To { get; set; } = default!;
    }
}

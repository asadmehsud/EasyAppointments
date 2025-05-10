using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.AdminDTOs
{
    public class SpecialityDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Select Status")]
        public int? Status { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs
{
    public record SaveClinicDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ClinicName { get; set; } = default!;

        [Required(ErrorMessage = "Select Province")]
        [Range(1, int.MaxValue)]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "Select City")]
        [Range(1, int.MaxValue)]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Address { get; set; } = default!;
        public int DoctorId { get; set; }
    }
}

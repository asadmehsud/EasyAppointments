using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs
{
    public record SaveCityDto
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Select Province")]
        [Range(1, int.MaxValue)]
        public int ProvinceId { get; set; }
        [Required(ErrorMessage = "Select Status")]
        public int? Status { get; set; }
    };

}

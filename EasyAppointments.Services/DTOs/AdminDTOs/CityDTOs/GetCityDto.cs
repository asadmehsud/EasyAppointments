using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs
{
    public record GetCityDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
        public int ProvinceId { get; set; }
        public int? Status { get; set; }
        public List<ProvinceDto> Provinces { get; set; } = new List<ProvinceDto>();
        public string ProvinceName { get; set; } = default!;
    }
}

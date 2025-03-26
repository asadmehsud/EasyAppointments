using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.AdminDTOs.ClinicDTOs
{
    public class GetClinicDto
    {
        public int Id { get; set; }

        public string ClinicName { get; set; } = default!;

        public int ProvinceId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; } = default!;

        public int? Status { get; set; }
        public List<ProvinceDto> Provinces { get; set; } = new List<ProvinceDto>();
        public IEnumerable<GetCityDto> Cities { get; set; } = new List<GetCityDto>();
        public GetCityDto City { get; set; } = new GetCityDto();
        public string ProvinceName { get; set; } = default!;
        public string CityName { get; set; } = default!;
    }
}

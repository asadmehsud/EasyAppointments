using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;

namespace EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs
{
    public class GetClinicDto
    {
        public int Id { get; set; }
        public string ClinicName { get; set; } = default!;

        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; } = default!;
        public int DoctorId { get; set; }
        public List<ProvinceDto>? Provinces { get; set; }
        public List<GetCityDto>? Cities { get; set; }
        public List<GetClinicDto>? Clinics { get; set; }

        //EEzafi
        public string ProvinceName { get; set; } = default!;
        public string CityName { get; set; } = default!;
        public GetCityDto City { get; set; } = default!;
    }
}

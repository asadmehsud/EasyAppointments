using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs;

namespace EasyAppointments.Services.DTOs.HomePageDTOs
{
    public record ViewModelHome
    {
        public List<SpecialityDto>? Specialities { get; set; }
        public List<DoctorDto>? Doctors { get; set; }
    }
}

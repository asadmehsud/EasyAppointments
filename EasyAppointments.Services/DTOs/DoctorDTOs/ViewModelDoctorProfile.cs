using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;

namespace EasyAppointments.Services.DTOs.DoctorDTOs
{
    public record ViewModelDoctorProfile
    {
        public DoctorDto? doctorDto { get; set; }
        public BreadcrumbDto? breadcrumbDto { get; set; }
        public List<GetClinicDto>? clinicDto { get; set; }
    }
}

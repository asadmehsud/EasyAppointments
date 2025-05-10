using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;

namespace EasyAppointments.Services.DTOs.DoctorDTOs
{
    public record ViewModelDoctorProfile
    {
        public DoctorDto? DoctorDto { get; set; }
        public BreadcrumbDto? BreadcrumbDto { get; set; }
        public List<GetClinicDto>? ClinicDto { get; set; }
        public List<ScheduleDto>? ScheduleDto { get; set; }
    }
}

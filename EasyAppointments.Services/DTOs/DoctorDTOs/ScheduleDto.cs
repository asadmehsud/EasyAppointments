using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.DoctorDTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DayId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string From { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string To { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public int AppointmentFee { get; set; }
        [Required(ErrorMessage = "Required")]
        public List<DayDto> Days { get; set; } = default!;
        public List<SaveClinicDto> Clinics { get; set; } = default!;
        public string DayName { get; set; } = default!;
        public string ClinicName { get; set; } = default!;
    }
}

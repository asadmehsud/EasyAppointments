using AutoMapper;
using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Data.Repositories.PatientRepositories.Interfaces;
using EasyAppointments.Services.DTOs.PatientDTOs;
using EasyAppointments.Services.Services.DoctorServices;

namespace EasyAppointments.Services.Services.PatientServices
{
    public class AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, DoctorService doctorService, PatientService patientService)
    {
        public async Task<int> SaveAsync(AppointmentDto appointmentDto)
        {
            DateTime parsedTime = DateTime.ParseExact(appointmentDto.Time, "HH:mm", null);
            appointmentDto.Time = parsedTime.ToString("hh:mm:tt");
            return await appointmentRepository.SaveAsync(mapper.Map<Appointment>(appointmentDto));
        }

        public async Task<int> UpdateAsync(AppointmentDto appointmentDto) => await appointmentRepository.UpdateAsync(mapper.Map<Appointment>(appointmentDto));
        public async Task<int> DeleteAsync(int id) => await appointmentRepository.DeleteAsync(await appointmentRepository.GetByIdAsync(id));
        public async Task<AppointmentDto> GetByIdAsync(int id) => mapper.Map<AppointmentDto>(await appointmentRepository.GetByIdAsync(id));
        public async Task<List<AppointmentDto>> GetAllAsync() => mapper.Map<List<AppointmentDto>>(await appointmentRepository.GetAllAsync());
        public async Task<AppointmentDto> GetAppointmentDetails(int doctorId, int patientId)
        {
            var doctor = await doctorService.GetByIdAsync(doctorId);
            var patient = await patientService.GetByIdAsync(patientId);
            AppointmentDto appointmentDto = new AppointmentDto();
            appointmentDto.DoctorId = doctorId;
            appointmentDto.DocotorName = doctor.FirstName + " " + doctor.LastName;
            appointmentDto.PatientId = patient.PatientId;
            appointmentDto.PatientName = patient.PatientName;
            return appointmentDto;
        }

    }
}

using AutoMapper;
using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Data.Repositories.PatientRepositories.Interfaces;
using EasyAppointments.Services.DoctorServices;
using EasyAppointments.Services.DTOs.PatientDTOs;

namespace EasyAppointments.Services.PatientServices
{
    public class AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, DoctorService doctorService, PatientService patientService)
    {
        public async Task<int> SaveAsync(AppointmentDto appointmentDto) => await appointmentRepository.SaveAsync(mapper.Map<Appointment>(appointmentDto));
        public async Task<int> UpdateAsync(AppointmentDto appointmentDto) => await appointmentRepository.UpdateAsync(mapper.Map<Appointment>(appointmentDto));
        public async Task<int> DeleteAsync(int id) => await appointmentRepository.DeleteAsync(await appointmentRepository.GetByIdAsync(id));
        public async Task<AppointmentDto> GetByIdAsync(int id) => mapper.Map<AppointmentDto>(await appointmentRepository.GetByIdAsync(id));
        public async Task<List<AppointmentDto>> GetAllAsync() => mapper.Map<List<AppointmentDto>>(await appointmentRepository.GetAllAsync());
        public async Task<AppointmentDto> BookAppointment(int doctorId)
        {
            var doctor = await doctorService.GetByIdAsync(doctorId);
            var patient = await patientService.GetByIdAsync(1);
            AppointmentDto appointmentDto = new AppointmentDto();
            appointmentDto.DoctorId = doctorId;
            appointmentDto.DocotorName = doctor.FirstName + " " + doctor.LastName;
            appointmentDto.PatientId = patient.PatientId;
            appointmentDto.PatientName = patient.PatientName;
            return appointmentDto;
        }
    }
}

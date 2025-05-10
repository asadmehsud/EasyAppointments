using AutoMapper;
using EasyAppointments.Core.Enum;
using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Data.Repositories.PatientRepositories.Interfaces;
using EasyAppointments.Services.DTOs.PatientDTOs;

namespace EasyAppointments.Services.Services.PatientServices
{
    public class PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        public async Task<int> SaveAsync(PatientDto patientDto)
        {
            patientDto.Role = Role.Patient;
            return await patientRepository.SaveAsync(mapper.Map<Patient>(patientDto));
        }

        public async Task<int> UpdateAsync(PatientDto patientDto) => await patientRepository.UpdateAsync(mapper.Map<Patient>(patientDto));
        public async Task<int> DeleteAsync(int id) => await patientRepository.DeleteAsync(await patientRepository.GetByIdAsync(id));
        public async Task<PatientDto> GetByIdAsync(int id) => mapper.Map<PatientDto>(await patientRepository.GetByIdAsync(id));
        public async Task<PatientDto> GetByIdentifierAsync(string identifier) => mapper.Map<PatientDto>(await patientRepository.GetByIdentifierAsync(identifier));
        public async Task<List<PatientDto>> GetAllAsync() => mapper.Map<List<PatientDto>>(await patientRepository.GetAllAsync());
    }
}

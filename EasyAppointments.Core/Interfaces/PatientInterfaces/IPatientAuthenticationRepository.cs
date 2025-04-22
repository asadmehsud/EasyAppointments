using EasyAppointments.Data.Entities.PatientEntities;

namespace EasyAppointments.Core.Interfaces.PatientInterfaces
{
    public interface IPatientAuthenticationRepository
    {
        Task<int> RegisterAsync(Patient patient);
        Task<Patient> LoginAsync(string patientIdentifier);
        Task<Patient> VerifyPasswordAsync(string Password);
    }
}

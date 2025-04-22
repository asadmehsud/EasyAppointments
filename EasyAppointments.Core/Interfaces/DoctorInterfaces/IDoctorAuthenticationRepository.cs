using EasyAppointments.Data.Entities.DoctorEntities;

namespace EasyAppointments.Core.Interfaces.DoctorInterfaces
{
    public interface IDoctorAuthenticationRepository
    {
        Task<int> RegisterAsync(Doctor doctor);
        Task<Doctor> LoginAsync(string doctorIdentifier);
        Task<Doctor> VerifyPasswordAsync(string Password);
    }
}

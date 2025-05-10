using EasyAppointments.Data.Entities.PatientEntities;

namespace EasyAppointments.Data.Repositories.PatientRepositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<int> SaveAsync(Patient patient);
        Task<int> UpdateAsync(Patient patient);
        Task<int> DeleteAsync(Patient patient);
        Task<Patient> GetByIdAsync(int Id);
        Task<Patient> GetByIdentifierAsync(string identifier);
        Task<List<Patient>> GetAllAsync();
    }
}

using EasyAppointments.Data.Entities.DoctorEntities;

namespace EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<int> SaveAsync(Doctor doctor);
        Task<int> UpdateAsync(Doctor doctor);
        Task<int> DeleteAsync(Doctor doctor);
        Task<Doctor> GetByIdAsync(int id);
        Task<Doctor> LoginAsync(Doctor doctor);
        Task<List<Doctor>> GetByStatusAsync(int Status);
        Task<List<Doctor>> GetAllAsync();
    }
}

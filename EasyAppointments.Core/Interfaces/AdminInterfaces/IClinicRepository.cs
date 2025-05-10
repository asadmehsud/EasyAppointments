using EasyAppointments.Data.Entities.AdminEntities;

namespace EasyAppointments.Core.Interfaces.AdminInterfaces
{
    public interface IClinicRepository
    {
        Task<int> SaveAsync(Clinic clinic);
        Task<int> UpdateAsync(Clinic clinic);
        Task<int> RemoveAsync(Clinic clinic);
        Task<List<Clinic>> GetAllAsync();
        Task<List<Clinic>> GetClinicByCityIdAsync(int ID);
        Task<Clinic> GetByIdAsync(int Id);
        Task<List<Clinic>> GetClinicByDoctorIdAsync(int ID);
        Task<Clinic> GetClinicByIdAndDoctorAsync(int clinicId, int doctorId);
    }
}

using EasyAppointments.Data.Entities.PatientEntities;

namespace EasyAppointments.Data.Repositories.PatientRepositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<int> SaveAsync(Appointment appointment);
        Task<int> UpdateAsync(Appointment appointment);
        Task<int> DeleteAsync(Appointment appointment);
        Task<Appointment> GetByIdAsync(int Id);
        Task<List<Appointment>> GetAllAsync();
    }
}

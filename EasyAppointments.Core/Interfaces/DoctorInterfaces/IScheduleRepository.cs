using EasyAppointments.Data.Entities.DoctorEntities;

namespace EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces
{
    public interface IScheduleRepository
    {
        Task<int> SaveAsync(Schedule schedule);
        Task<int> UpdateAsync(Schedule schedule);
        Task<int> DeleteAsync(Schedule schedule);
        Task<Schedule> GetByIdAsync(int id);
        Task<List<Schedule>> GetAllAsync();
    }
}

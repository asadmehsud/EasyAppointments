using EasyAppointments.Data.Entities.AdminEntities;

namespace EasyAppointments.Core.Interfaces.AdminInterfaces
{
    public interface ITimeRepository
    {
        Task<int> SaveAsync(Time time);
        Task<int> UpdateAsync(Time time);
        Task<int> RemoveAsync(Time time);
        Task<Time> GetByIdAsync(int id);
        Task<List<Time>> GetAllAsync();
    }
}

using EasyAppointments.Data.Entities.AdminEntities;

namespace EasyAppointments.Core.Interfaces.AdminInterfaces
{
    public interface IDayRepository
    {
        Task<int> SaveAsync(Day day);
        Task<int> UpdateAsync(Day day);
        Task<int> RemoveAsync(Day day);
        Task<Day> GetByIdAsync(int id);
        Task<List<Day>> GetAllAsync();
    }
}

using EasyAppointments.Data.Entities.AdminEntities;

namespace EasyAppointments.Core.Interfaces.AdminInterfaces
{
    public interface IAdminRepository
    {
        Task<int> SaveAsync(Admin admin);
        Task<int> UpdateAsync(Admin admin);
        Task<int> RemoveAsync(Admin admin);
        Task<Admin> GetByIdAsync(int id);
        Task<List<Admin>> GetAllAsync();

    }
}

using EasyAppointments.Data.Entities.AdminEntities;

namespace EasyAppointments.Core.Interfaces.AdminInterfaces
{
    public interface IProvinceRepository
    {
        Task<int> SaveAsync(Province province);
        Task<int> UpdateAsync(Province province);
        Task<int> RemoveAsync(Province province);
        Task<Province> GetByIdAsync(int id);
        Task<List<Province>> GetAllAsync();
    }
}

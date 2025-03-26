using EasyAppointments.Data.Entities.AdminEntities;

namespace EasyAppointments.Core.Interfaces.AdminInterfaces
{
    public interface ICityRepository
    {
        Task<int> SaveAsync(City city);
        Task<int> UpdateAsync(City city);
        Task<int> RemoveAsync(City city);
        Task<City> GetByIdAsync(int id);
        Task<List<City>> GetCityByProvinceId(int id);
        Task<List<City>> GetAllAsync();
    }
}

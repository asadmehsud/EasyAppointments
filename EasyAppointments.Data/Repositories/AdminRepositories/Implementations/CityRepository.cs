using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.AdminRepositories.Implementations
{
    public class CityRepository(DbEasyAppointmentsContext context) : ICityRepository
    {
        public async Task<List<City>> GetAllAsync() => await context.Cities.ToListAsync();

        public async Task<City> GetByIdAsync(int Id) => await context.Cities.Where(a => a.Id == Id).SingleAsync();
        public async Task<List<City>> GetCityByProvinceId(int Id) => await context.Cities.Where(a => a.ProvinceId == Id).ToListAsync();

        public async Task<int> RemoveAsync(City city)
        {
            context.Cities.Remove(city);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(City city)
        {
            await context.Cities.AddAsync(city);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(City city)
        {
            context.Cities.Update(city);
            return await context.SaveChangesAsync();
        }
    }
}

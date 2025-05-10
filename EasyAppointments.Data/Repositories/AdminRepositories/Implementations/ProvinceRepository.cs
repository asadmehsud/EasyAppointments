using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.AdminRepositories.Implementations
{
    public class ProvinceRepository(DbEasyAppointmentsContext context) : IProvinceRepository
    {
        public async Task<List<Province>> GetAllAsync()
        {
            return await context.Provinces.ToListAsync();
        }

        public async Task<Province> GetByIdAsync(int Id)
        {
            var province = await context.Provinces.SingleOrDefaultAsync(a => a.Id == Id);
            return province is null ? new Province() : province;
        }

        public async Task<int> RemoveAsync(Province province)
        {
            context.Provinces.Remove(province);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(Province province)
        {
            await context.Provinces.AddAsync(province);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Province province)
        {
            try
            {
                context.Provinces.Update(province);
                return await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.AdminRepositories.Implementations
{
    public class AdminRepository(DbEasyAppointmentsContext context) : IAdminRepository
    {
        public async Task<List<Admin>> GetAllAsync() => await context.Admins.ToListAsync();

        public async Task<Admin> GetByIdAsync(int id) => await context.Admins.Where(a => a.Id == id).SingleAsync();

        public async Task<int> RemoveAsync(Admin admin)
        {
            context.Admins.Remove(admin);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(Admin admin)
        {
            await context.AddAsync(admin);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Admin admin)
        {
            context.Admins.Update(admin);
            return await context.SaveChangesAsync();
        }
    }
}

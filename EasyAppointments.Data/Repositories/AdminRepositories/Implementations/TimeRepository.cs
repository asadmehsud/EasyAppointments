using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.AdminRepositories.Implementations
{
    public class TimeRepository(DbEasyAppointmentsContext context) : ITimeRepository
    {
        public async Task<List<Time>> GetAllAsync() => await context.Times.ToListAsync();
        public async Task<Time> GetByIdAsync(int id) => await context.Times.Where(a => a.Id == id).SingleAsync();
        public async Task<int> RemoveAsync(Time time)
        {
            context.Times.Remove(time);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(Time time)
        {
            await context.Times.AddAsync(time);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Time time)
        {
            context.Times.Update(time);
            return await context.SaveChangesAsync();
        }
    }
}

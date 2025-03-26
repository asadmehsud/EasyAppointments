using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.AdminRepositories.Implementations
{
    public class DayRepository(DbEasyAppointmentsContext context) : IDayRepository
    {
        public async Task<List<Day>> GetAllAsync() => await context.Days.ToListAsync();
        public async Task<Day> GetByIdAsync(int id) => await context.Days.Where(a => a.Id == id).SingleAsync();
        public async Task<int> RemoveAsync(Day day)
        {
            context.Days.Remove(day);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(Day day)
        {
            await context.Days.AddAsync(day);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Day day)
        {
            context.Days.Update(day);
            return await context.SaveChangesAsync();
        }
    }
}

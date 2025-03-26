using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.DoctorRepositories.Implementations
{
    public class ScheduleRepository(DbEasyAppointmentsContext context):IScheduleRepository
    {
        public async Task<List<Schedule>> GetAllAsync() => await context.Schedules.ToListAsync();

        public async Task<Schedule> GetByIdAsync(int id) => await context.Schedules.Where(op => op.Id == id).SingleAsync();
        public async Task<int> DeleteAsync(Schedule schedule)
        {
            context.Schedules.Remove(schedule);
            return await context.SaveChangesAsync();
        }
        public async Task<int> SaveAsync(Schedule schedule)
        {
            var doc = await context.Schedules.AddAsync(schedule);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Schedule schedule)
        {
            context.Schedules.Update(schedule);
            return await context.SaveChangesAsync();
        }
    }
}

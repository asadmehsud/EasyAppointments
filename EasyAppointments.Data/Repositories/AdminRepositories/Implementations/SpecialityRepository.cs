using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.AdminRepositories.Implementations
{
    public class SpecialityRepository(DbEasyAppointmentsContext context) : ISpecialityRepository
    {
        public async Task<List<Speciality>> GetAllAsync() => await context.Specialities.ToListAsync();

        public async Task<Speciality> GetByIdAsync(int id)
        {
            var speciality = await context.Specialities.SingleOrDefaultAsync(a => a.Id == id);
            if (speciality is null)
            {
                return null!;
            }
            return speciality;
        }

        public async Task<int> RemoveAsync(Speciality speciality)
        {
            context.Specialities.Remove(speciality);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(Speciality speciality)
        {
            await context.Specialities.AddAsync(speciality);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Speciality speciality)
        {
            context.Specialities.Update(speciality);
            return await context.SaveChangesAsync();
        }
    }
}

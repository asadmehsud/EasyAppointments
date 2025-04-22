using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.AdminRepositories.Implementations
{
    public class ClinicRepository(DbEasyAppointmentsContext context) : IClinicRepository
    {
        public async Task<List<Clinic>> GetAllAsync() => await context.Clinics.ToListAsync();

        public async Task<Clinic> GetByIdAsync(int Id)
        {
            var clinic = await context.Clinics.SingleOrDefaultAsync(a => a.Id == Id);
            if (clinic is null)
            {
                return null!;
            }
            return clinic;
        }

        public async Task<List<Clinic>> GetClinicByCityIdAsync(int ID) => await context.Clinics.Where(a => a.CityId == ID).ToListAsync();
        public async Task<List<Clinic>> GetClinicByDoctorIdAsync(int ID) => await context.Clinics.Where(a => a.DoctorId == ID).ToListAsync();

        public async Task<int> RemoveAsync(Clinic medicalCenter)
        {
            context.Clinics.Remove(medicalCenter);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(Clinic medicalCenter)
        {
            await context.Clinics.AddAsync(medicalCenter);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Clinic medicalCenter)
        {
            context.Clinics.Update(medicalCenter);
            return await context.SaveChangesAsync();
        }
    }
}

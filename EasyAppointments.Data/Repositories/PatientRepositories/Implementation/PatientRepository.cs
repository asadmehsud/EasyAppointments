using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Data.Repositories.PatientRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.PatientRepositories.Implementation
{
    public class PatientRepository(DbEasyAppointmentsContext context) : IPatientRepository
    {
        public Task<Patient> LoginAsync(Patient patient) => context.Patients.Where(a => a.Contact == patient.Contact && a.Password == patient.Password).FirstOrDefaultAsync()!;
        public async Task<List<Patient>> GetAllAsync() => await context.Patients.ToListAsync();
        public async Task<Patient> GetByIdAsync(int Id) => await context.Patients.Where(a => a.PatientId == Id).SingleAsync();
        public async Task<int> DeleteAsync(Patient patient)
        {
            context.Patients.Remove(patient);
            return await context.SaveChangesAsync();
        }
        public async Task<int> SaveAsync(Patient patient)
        {
            var returnedValue = await context.Patients.AddAsync(patient);
            await context.SaveChangesAsync();
            return returnedValue.Entity.PatientId;
        }
        public async Task<int> UpdateAsync(Patient patient)
        {
            context.Patients.Update(patient);
            return await context.SaveChangesAsync();
        }
    }
}

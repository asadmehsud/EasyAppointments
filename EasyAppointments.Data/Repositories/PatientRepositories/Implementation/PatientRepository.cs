using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Data.Repositories.PatientRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.PatientRepositories.Implementation
{
    public class PatientRepository(DbEasyAppointmentsContext context) : IPatientRepository
    {
        public async Task<List<Patient>> GetAllAsync() => await context.Patients.ToListAsync();
        public async Task<Patient> GetByIdAsync(int Id)
        {
            var patient = await context.Patients.SingleOrDefaultAsync(a => a.PatientId == Id);
            return patient is null ? null! : patient;
        }
        public async Task<Patient> GetByIdentifierAsync(string identifier)
        {
            var patient = await context.Patients.SingleOrDefaultAsync(a => a.Email == identifier || a.Contact == identifier);
            return patient is null ? null! : patient;
        }

        public async Task<int> DeleteAsync(Patient patient)
        {
            context.Patients.Remove(patient);
            return await context.SaveChangesAsync();
        }
        public async Task<int> SaveAsync(Patient patient)
        {
            try
            {
                await context.Patients.AddAsync(patient);
                await context.SaveChangesAsync();
                return (int)ResponseType.Success;
            }
            catch (Exception)
            {
                return (int)ResponseType.InternalServerError;
            }
        }
        public async Task<int> UpdateAsync(Patient patient)
        {
            try
            {
                context.Patients.Update(patient);
                return await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return (int)ResponseType.InternalServerError;
            }
        }
    }
}

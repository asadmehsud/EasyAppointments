using EasyAppointments.Core.Interfaces.PatientInterfaces;
using EasyAppointments.Data.Entities.PatientEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.PatientRepositories.Implementation
{
    public class PatientAuthenticationRepository(DbEasyAppointmentsContext context) : IPatientAuthenticationRepository
    {
        public async Task<Patient> LoginAsync(string patientIdentifier)
        {
            var patient = await context.Patients
               .FirstOrDefaultAsync(a => a.Email == patientIdentifier || a.Contact == patientIdentifier);
            return patient is null ? null! : patient;
        }
        public async Task<Patient> VerifyPasswordAsync(string Password)
        {
            var patient = await context.Patients
               .FirstOrDefaultAsync(a => a.Password == Password);
            if (patient is null)
            {
                return null!;
            }
            return patient;
        }

        public async Task<int> RegisterAsync(Patient patient)
        {
            var data = await context.Patients.FirstOrDefaultAsync(a => a.Email == patient.Email);
            if (data is null)
            {
                await context.Patients.AddAsync(patient);
                return await context.SaveChangesAsync();
            }
            return (int)ResponseType.RecordAlreadyExist;
        }
    }
}

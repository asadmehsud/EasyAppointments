using EasyAppointments.Core.Interfaces.DoctorInterfaces;
using EasyAppointments.Data.Entities.DoctorEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.DoctorRepositories.Implementations
{
    public class DoctorAuthenticationRepository(DbEasyAppointmentsContext context) : IDoctorAuthenticationRepository
    {
        public async Task<Doctor> LoginAsync(string doctorIdentifier)
        {
            var doctor = await context.Doctors
               .FirstOrDefaultAsync(a => a.UserName == doctorIdentifier || a.Email == doctorIdentifier || a.Contact == doctorIdentifier);
            return doctor is null ? null! : doctor;
        }
        public async Task<Doctor> VerifyPasswordAsync(string Password)
        {
            var doctor = await context.Doctors
               .FirstOrDefaultAsync(a => a.Password == Password);
            if (doctor is null)
            {
                return null!;
            }
            return doctor;
        }

        public async Task<int> RegisterAsync(Doctor doctor)
        {
            try
            {
                var data = await context.Doctors.FirstOrDefaultAsync(a => a.Email == doctor.Email || a.UserName == doctor.UserName || a.Contact == doctor.Contact);
                if (data is null)
                {
                    await context.Doctors.AddAsync(doctor);
                    await context.SaveChangesAsync();
                    return (int)ResponseType.Success;
                }
                return (int)ResponseType.RecordAlreadyExist;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

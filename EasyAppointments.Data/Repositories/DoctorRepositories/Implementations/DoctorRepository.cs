using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.DoctorRepositories.Implementations
{

    public class DoctorRepository(DbEasyAppointmentsContext context) : IDoctorRepository
    {
        public async Task<List<Doctor>> GetAllAsync() => await context.Doctors.ToListAsync();

        public async Task<Doctor> GetByIdAsync(int id)
        {
            var doctor = await context.Doctors.SingleOrDefaultAsync(op => op.Id == id);
            if (doctor is null)
            {
                return null!;
            }
            return doctor;
        }
        public async Task<Doctor> GetByIdentifierAsync(string identifier)
        {
            var doctor = await context.Doctors.FirstOrDefaultAsync(op => op.Email == identifier || op.Contact == identifier || op.UserName == identifier);
            if (doctor is null)
            {
                return null!;
            }
            return doctor;
        }

        public async Task<List<Doctor>> GetByStatusAsync(int Status) => await context.Doctors.Where(a => a.Status == Status).ToListAsync();

        public Task<Doctor> LoginAsync(Doctor doctor) => context.Doctors.Where(a => a.Contact == doctor.Contact && a.Password == doctor.Password).FirstOrDefaultAsync()!;
        public async Task<int> DeleteAsync(Doctor doctor)
        {
            context.Doctors.Remove(doctor);
            return await context.SaveChangesAsync();
        }
        public async Task<int> SaveAsync(Doctor doctor)
        {
            var doc = await context.Doctors.AddAsync(doctor);
            await context.SaveChangesAsync();
            int doctorId = doc.Entity.Id;
            return doctorId;
        }

        public async Task<int> UpdateAsync(Doctor doctor)
        {
            try
            {
                // Find the existing tracked entity
                var existingDoctor = context.Doctors.Local.FirstOrDefault(e => e.Id == doctor.Id);

                // Detach the existing entity if it exists
                if (existingDoctor != null)
                {
                    context.Entry(existingDoctor).State = EntityState.Detached;
                }

                // Attach and update the new instance
                context.Doctors.Update(doctor);
                return await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Data.Repositories.PatientRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.PatientRepositories.Implementation
{
    public class AppointmentRepository(DbEasyAppointmentsContext context) : IAppointmentRepository
    {
        public async Task<List<Appointment>> GetAllAsync() => await context.Appointments.ToListAsync();
        public async Task<Appointment> GetByIdAsync(int Id) => await context.Appointments.Where(a => a.Id == Id).SingleAsync();
        public async Task<int> DeleteAsync(Appointment appointment)
        {
            context.Appointments.Remove(appointment);
            return await context.SaveChangesAsync();
        }
        public async Task<int> SaveAsync(Appointment appointment)
        {
            await context.Appointments.AddAsync(appointment);
            return await context.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(Appointment appointment)
        {
            context.Appointments.Update(appointment);
            return await context.SaveChangesAsync();
        }
    }
}

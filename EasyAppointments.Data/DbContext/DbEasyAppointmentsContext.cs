using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Entities.PatientEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data
{
    public class DbEasyAppointmentsContext(DbContextOptions<DbEasyAppointmentsContext> options) : DbContext(options)
    {
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}

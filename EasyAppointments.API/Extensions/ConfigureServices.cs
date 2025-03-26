using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data;
using EasyAppointments.Data.Repositories.AdminRepositories.Implementations;
using EasyAppointments.Data.Repositories.DoctorRepositories.Implementations;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using EasyAppointments.Data.Repositories.PatientRepositories.Implementation;
using EasyAppointments.Data.Repositories.PatientRepositories.Interfaces;
using EasyAppointments.Services.AdminServices;
using EasyAppointments.Services.Authentication;
using EasyAppointments.Services.DoctorServices;
using EasyAppointments.Services.PatientServices;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.API.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(Mapper)).AddScoped<CityService>()
                .AddScoped<ICityRepository, CityRepository>()
                .AddScoped<ProvinceService>()
                .AddScoped<IProvinceRepository, ProvinceRepository>()
                .AddScoped<ClinicService>()
                .AddScoped<IClinicRepository, ClinicRepository>()
                .AddScoped<DayService>()
                .AddScoped<IDayRepository, DayRepository>()
                .AddScoped<TimeService>()
                .AddScoped<ITimeRepository, TimeRepository>()
                .AddScoped<AdminService>()
                .AddScoped<IAdminRepository, AdminRepository>()
                .AddScoped<SpecialityService>()
                .AddScoped<ISpecialityRepository, SpecialityRepository>()
                .AddScoped<DoctorService>()
                .AddScoped<IDoctorRepository, DoctorRepository>()
                .AddScoped<PatientService>()
                .AddScoped<IPatientRepository, PatientRepository>()
                .AddScoped<AppointmentService>()
                .AddScoped<IAppointmentRepository, AppointmentRepository>()
                .AddScoped<ScheduleService>()
                .AddScoped<IScheduleRepository, ScheduleRepository>()
                .AddScoped<AdminAuthenticationService>()
                .AddScoped<IAdminAuthenticationRepository, AdminAuthenticationRepository>()
                .AddScoped<CookiesService>()
                .AddHttpContextAccessor();
        }
        public static IServiceCollection AddConnections(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DbEasyAppointmentsContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen();
        }
    }
}

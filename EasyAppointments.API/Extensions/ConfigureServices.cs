﻿using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Core.Interfaces.DoctorInterfaces;
using EasyAppointments.Core.Interfaces.PatientInterfaces;
using EasyAppointments.Data;
using EasyAppointments.Data.Repositories.AdminRepositories.Implementations;
using EasyAppointments.Data.Repositories.DoctorRepositories.Implementations;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using EasyAppointments.Data.Repositories.PatientRepositories.Implementation;
using EasyAppointments.Data.Repositories.PatientRepositories.Interfaces;
using EasyAppointments.Services.Authentication;
using EasyAppointments.Services.Services;
using EasyAppointments.Services.Services.AdminServices;
using EasyAppointments.Services.Services.DoctorServices;
using EasyAppointments.Services.Services.PatientServices;
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
                .AddScoped<PatientAuthenticationService>()
                .AddScoped<IPatientAuthenticationRepository, PatientAuthenticationRepository>()
                .AddScoped<DoctorAuthenticationService>()
                .AddScoped<IDoctorAuthenticationRepository, DoctorAuthenticationRepository>()
                .AddScoped<HomePageService>();

        }
        public static IServiceCollection AddConnections(this IServiceCollection services, IConfiguration configuration)
        {
            var con = configuration["ConnectionString"];
            return services.AddDbContext<DbEasyAppointmentsContext>(options => options.UseSqlServer(con));
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen();
        }
    }
}

using AutoMapper;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;
using EasyAppointments.Services.DTOs.PatientDTOs;

namespace EasyAppointments
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ProvinceDto, Province>().ReverseMap();
            CreateMap<GetCityDto, City>().ReverseMap();
            CreateMap<SaveCityDto, City>().ReverseMap();
            CreateMap<SaveClinicDto, Clinic>().ReverseMap();
            CreateMap<GetClinicDto, Clinic>().ReverseMap();
            CreateMap<SpecialityDto, Speciality>().ReverseMap();
            CreateMap<DoctorDto, Doctor>().ReverseMap();
            CreateMap<PatientDto, Patient>().ReverseMap();
            CreateMap<AdminRegisterDto, Admin>().ReverseMap();
            CreateMap<AdminLoginDto, Admin>().ReverseMap();
            CreateMap<DayDto, Day>().ReverseMap();
            CreateMap<TimeDto, Time>().ReverseMap();
            CreateMap<PatientRegisterDto, Patient>().ReverseMap();
            CreateMap<PatientLoginDto, Patient>().ReverseMap();
            CreateMap<DoctorRegisterDto, Doctor>().ReverseMap();
            CreateMap<DoctorLoginDto, Doctor>().ReverseMap();
            CreateMap<BasicDetailsDto, Doctor>().ReverseMap();
            CreateMap<ScheduleDto, Schedule>().ReverseMap();
            CreateMap<AppointmentDto, Appointment>().ReverseMap();
        }
    }
}

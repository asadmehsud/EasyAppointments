using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;

namespace EasyAppointments.Services.Services.DoctorServices
{
    public class ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper, IDayRepository dayRepository, IClinicRepository clinicRepository)
    {
        public async Task<int> SaveAsync(ScheduleDto scheduleDto)
        {
            DateTime parsedTimeFrom = DateTime.ParseExact(scheduleDto.From, "HH:mm", null);
            DateTime parsedTimeTo = DateTime.ParseExact(scheduleDto.To, "HH:mm", null);
            scheduleDto.From = parsedTimeFrom.ToString("hh:mm:tt");
            scheduleDto.To = parsedTimeTo.ToString("hh:mm:tt");
            return await scheduleRepository.SaveAsync(mapper.Map<Schedule>(scheduleDto));
        }

        public async Task<int> UpdateAsync(ScheduleDto scheduleDto) => await scheduleRepository.UpdateAsync(mapper.Map<Schedule>(scheduleDto));
        public async Task<int> RemoveAsync(int Id) => await scheduleRepository.DeleteAsync(await scheduleRepository.GetByIdAsync(Id));
        public async Task<ScheduleDto> GetByIdAsync(int Id)
        {
            var schedule = mapper.Map<ScheduleDto>(await scheduleRepository.GetByIdAsync(Id));
            schedule.Clinics = mapper.Map<List<SaveClinicDto>>(await clinicRepository.GetAllAsync());
            schedule.Days = mapper.Map<List<DayDto>>(await dayRepository.GetAllAsync());
            schedule.From = ConvertTimeFormat(schedule.From);
            schedule.To = ConvertTimeFormat(schedule.To);
            return schedule;
        }
        public string ConvertTimeFormat(string time)
        {
            DateTime parsedTime = DateTime.ParseExact(time, "hh:mm:tt", null);
            return parsedTime.ToString("HH:mm");
        }
        public async Task<List<ScheduleDto>> GetAllAsync() => mapper.Map<List<ScheduleDto>>(await scheduleRepository.GetAllAsync());

        public async Task<ScheduleDto> GetScheduleDetails(int doctorId)
        {
            ScheduleDto scheduleDto = new ScheduleDto();
            var days = await dayRepository.GetAllAsync();
            var clinics = await clinicRepository.GetClinicByDoctorIdAsync(doctorId);
            scheduleDto.DoctorId = doctorId;
            scheduleDto.Clinics = mapper.Map<List<SaveClinicDto>>(clinics);
            scheduleDto.Days = mapper.Map<List<DayDto>>(days);
            scheduleDto.Days = mapper.Map<List<DayDto>>(days);
            return scheduleDto;
        }
        public async Task<List<ScheduleDto>> GetScheduleList(int doctorId)
        {
            var scheduleDto = new List<ScheduleDto>();
            scheduleDto = mapper.Map<List<ScheduleDto>>(await scheduleRepository.GetByDoctorIdAsync(doctorId));
            if (scheduleDto.Count > 0)
            {
                var clinic = await clinicRepository.GetByIdAsync(scheduleDto.FirstOrDefault()!.ClinicId);
                var day = mapper.Map<DayDto>(await dayRepository.GetByIdAsync(scheduleDto.FirstOrDefault()!.DayId));
                scheduleDto.FirstOrDefault()!.ClinicName = clinic.ClinicName!;
                scheduleDto.FirstOrDefault()!.DayName = day.WeekDay!;
                return scheduleDto;
            }
            return null!;
        }
        public async Task<ScheduleDto> GetToInsertSchedule(int doctorId)
        {
            var scheduleDto = new ScheduleDto();
            scheduleDto.Clinics = mapper.Map<List<SaveClinicDto>>(await clinicRepository.GetAllAsync());
            scheduleDto.Days = mapper.Map<List<DayDto>>(await dayRepository.GetAllAsync());
            scheduleDto.DoctorId = doctorId;
            return scheduleDto;
        }
    }
}

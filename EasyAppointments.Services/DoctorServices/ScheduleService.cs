using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;

namespace EasyAppointments.Services.DoctorServices
{
    public class ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper,IDayRepository dayRepository,IClinicRepository clinicRepository)
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
        public async Task<ScheduleDto> GetByIdAsync(int Id) => mapper.Map<ScheduleDto>(await scheduleRepository.GetByIdAsync(Id));
        public async Task<List<ScheduleDto>> GetAllAsync() => mapper.Map<List<ScheduleDto>>(await scheduleRepository.GetAllAsync());

        public async Task<ScheduleDto> GetScheduleDetails(int doctorId)
        {
            ScheduleDto scheduleDto = new ScheduleDto();
            var days = await dayRepository.GetAllAsync();
            var clinics = await clinicRepository.GetClinicByDoctorIdAsync(doctorId);
            scheduleDto.DoctorId = doctorId;
            scheduleDto.Clinics = mapper.Map<List<SaveClinicDto>>(clinics);
            scheduleDto.Days = mapper.Map<List<DayDto>>(days);
            return scheduleDto;
        }
        //public async Task<TimeDto> GetToShowTimeAsync(int timeId)
        //{
        //    var time = mapper.Map<TimeDto>(await timeRepository.GetByIdAsync(timeId));
        //    DateTime parsedTimeFrom = DateTime.ParseExact(time.From, "h:mm:tt", null);
        //    DateTime parsedTimeTo = DateTime.ParseExact(time.To, "h:mm:tt", null);
        //    time.From = parsedTimeFrom.ToString("HH:mm");
        //    time.To = parsedTimeTo.ToString("HH:mm");
        //    return time;
        //}
    }
}

using AutoMapper;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using EasyAppointments.Services.DTOs.DoctorDTOs;

namespace EasyAppointments.Services.DoctorServices
{
    public class ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
    {
        public async Task<int> SaveAsync(ScheduleDto scheduleDto) => await scheduleRepository.SaveAsync(mapper.Map<Schedule>(scheduleDto));
        public async Task<int> UpdateAsync(ScheduleDto scheduleDto) => await scheduleRepository.UpdateAsync(mapper.Map<Schedule>(scheduleDto));
        public async Task<int> RemoveAsync(int Id) => await scheduleRepository.DeleteAsync(await scheduleRepository.GetByIdAsync(Id));
        public async Task<ScheduleDto> GetByIdAsync(int Id) => mapper.Map<ScheduleDto>(await scheduleRepository.GetByIdAsync(Id));
        public async Task<List<ScheduleDto>> GetAllAsync() => mapper.Map<List<ScheduleDto>>(await scheduleRepository.GetAllAsync());
    }
}

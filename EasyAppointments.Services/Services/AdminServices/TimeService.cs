using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;

namespace EasyAppointments.Services.Services.AdminServices
{
    public class TimeService(ITimeRepository timeRepository, IMapper mapper)
    {
        public async Task<int> SaveAsync(TimeDto timeDto)
        {
            DateTime parsedTimeFrom = DateTime.ParseExact(timeDto.From, "HH:mm", null);
            DateTime parsedTimeTo = DateTime.ParseExact(timeDto.To, "HH:mm", null);
            timeDto.From = parsedTimeFrom.ToString("h:mm:tt");
            timeDto.To = parsedTimeTo.ToString("hh:mm:tt");
            return await timeRepository.SaveAsync(mapper.Map<Time>(timeDto));
        }

        public async Task<int> UpdateAsync(TimeDto timeDto) => await timeRepository.UpdateAsync(mapper.Map<Time>(timeDto));
        public async Task<int> RemoveAsync(int Id) => await timeRepository.RemoveAsync(await timeRepository.GetByIdAsync(Id));
        public async Task<List<TimeDto>> GetAllAsync() => mapper.Map<List<TimeDto>>(await timeRepository.GetAllAsync());
        public async Task<TimeDto> GetByIdAsync(int Id) => mapper.Map<TimeDto>(await timeRepository.GetByIdAsync(Id));
        public async Task<TimeDto> GetToShowTimeAsync(int timeId)
        {
            var time = mapper.Map<TimeDto>(await timeRepository.GetByIdAsync(timeId));
            DateTime parsedTimeFrom = DateTime.ParseExact(time.From, "h:mm:tt", null);
            DateTime parsedTimeTo = DateTime.ParseExact(time.To, "h:mm:tt", null);
            time.From = parsedTimeFrom.ToString("HH:mm");
            time.To = parsedTimeTo.ToString("HH:mm");
            return time;
        }
    }
}

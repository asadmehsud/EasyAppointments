using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;

namespace EasyAppointments.Services.AdminServices
{
    public class DayService(IDayRepository dayRepository, IMapper mapper)
    {
        public async Task<int> SaveAsync(DayDto dayDto) => await dayRepository.SaveAsync(mapper.Map<Day>(dayDto));
        public async Task<int> UpdateAsync(DayDto dayDto) => await dayRepository.UpdateAsync(mapper.Map<Day>(dayDto));
        public async Task<int> RemoveAsync(int Id) => await dayRepository.RemoveAsync(await dayRepository.GetByIdAsync(Id));
        public async Task<List<DayDto>> GetAllAsync() => mapper.Map<List<DayDto>>(await dayRepository.GetAllAsync());
        public async Task<DayDto> GetByIdAsync(int Id) => mapper.Map<DayDto>(await dayRepository.GetByIdAsync(Id));
    }
}

using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;

namespace EasyAppointments.Services.AdminServices
{
    public class SpecialityService(ISpecialityRepository specialityRepository, IMapper mapper)
    {
        public async Task<IEnumerable<SpecialityDto>> GetAllAsync() => mapper.Map<IEnumerable<SpecialityDto>>(await specialityRepository.GetAllAsync());
        public async Task<SpecialityDto> GetByIdAsync(int Id) => mapper.Map<SpecialityDto>(await specialityRepository.GetByIdAsync(Id));
        public async Task<int> RemoveAsync(int Id) => await specialityRepository.RemoveAsync(await specialityRepository.GetByIdAsync(Id));
        public async Task<int> UpdateAsync(SpecialityDto specialitydto) => await specialityRepository.UpdateAsync(mapper.Map<Speciality>(specialitydto));
        public async Task<int> SaveAsync(SpecialityDto specialitydto) => await specialityRepository.SaveAsync(mapper.Map<Speciality>(specialitydto));
    }
}

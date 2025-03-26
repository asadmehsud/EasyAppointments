using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;

namespace EasyAppointments.Services.AdminServices
{
    public class ProvinceService(IProvinceRepository provinceRepository, IMapper mapper)
    {
        public async Task<int> SaveAsync(ProvinceDto provinceDto)
        {
            return await provinceRepository.SaveAsync(mapper.Map<Province>(provinceDto));
        }

        public async Task<int> UpdateAsync(ProvinceDto provinceDto)
        {
            return await provinceRepository.UpdateAsync(mapper.Map<Province>(provinceDto));
        }

        public async Task<int> RemoveAsync(int Id)
        {
            var province = await provinceRepository.GetByIdAsync(Id);
            return await provinceRepository.RemoveAsync(province);
        }

        public async Task<ProvinceDto> GetByIdAsync(int Id)
        {
            return mapper.Map<ProvinceDto>(await provinceRepository.GetByIdAsync(Id));
        }

        public async Task<List<ProvinceDto>> GetAllAsync()
        {
            return mapper.Map<List<ProvinceDto>>(await provinceRepository.GetAllAsync());
        }
    }
}

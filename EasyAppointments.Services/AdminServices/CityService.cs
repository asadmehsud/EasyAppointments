using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;

namespace EasyAppointments.Services.AdminServices
{
    public class CityService(ICityRepository cityRepository, IProvinceRepository provinceRepository, IMapper mapper)
    {
        public async Task<int> SaveAsync(SaveCityDto cityDto) => await cityRepository.SaveAsync(mapper.Map<City>(cityDto));
        public async Task<int> UpdateAsync(SaveCityDto cityDto) => await cityRepository.UpdateAsync(mapper.Map<City>(cityDto));
        public async Task<int> RemoveAsync(int Id) => await cityRepository.RemoveAsync(await cityRepository.GetByIdAsync(Id));
        public async Task<List<GetCityDto>> GetCityByProvinceId(int Id) => mapper.Map<List<GetCityDto>>(await cityRepository.GetCityByProvinceId(Id));
        public async Task<GetCityDto> GetByIdAsync(int Id)
        {
            var citydto = mapper.Map<GetCityDto>(await cityRepository.GetByIdAsync(Id));
            var provinces = mapper.Map<List<ProvinceDto>>(await provinceRepository.GetAllAsync());
            citydto.Provinces = provinces;
            return citydto;
        }
        public async Task<IEnumerable<GetCityDto>> GetAllAsync()
        {
            var provinces = await provinceRepository.GetAllAsync();
            var cities = await cityRepository.GetAllAsync();
            var jointData = from pr in provinces
                            join ct in cities on pr.Id equals ct.ProvinceId
                            select new GetCityDto
                            {
                                Id = ct.Id,
                                Name = ct.Name,
                                ProvinceName = pr.ProvinceName,
                                Status = ct.Status,
                                ProvinceId = ct.ProvinceId,
                            };
            return jointData;
        }
    }
}

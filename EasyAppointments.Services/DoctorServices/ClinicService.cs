using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;

namespace EasyAppointments.Services.DoctorServices
{
    public class ClinicService(IClinicRepository clinicRepository, IMapper mapper, IProvinceRepository provinceRepository, ICityRepository cityRepository)
    {
        public async Task<int> SaveAsync(SaveClinicDto clinicDto)
        {
            return await clinicRepository.SaveAsync(mapper.Map<Clinic>(clinicDto));
        }

        public async Task<int> UpdateAsync(SaveClinicDto clinicDto) => await clinicRepository.UpdateAsync(mapper.Map<Clinic>(clinicDto));
        public async Task<int> RemoveAsync(int Id) => await clinicRepository.RemoveAsync(await clinicRepository.GetByIdAsync(Id));
        public async Task<IEnumerable<GetClinicDto>> GetClinicByCityIdAsync(int cityId) => mapper.Map<IEnumerable<GetClinicDto>>(await clinicRepository.GetClinicByCityIdAsync(cityId));
        public async Task<GetClinicDto> GetByIdAsync(int Id)
        {
            var clinicDto = mapper.Map<GetClinicDto>(await clinicRepository.GetByIdAsync(Id));
            clinicDto.Provinces = mapper.Map<List<ProvinceDto>>(await provinceRepository.GetAllAsync());
            clinicDto.City = mapper.Map<GetCityDto>(await cityRepository.GetByIdAsync(clinicDto.CityId));
            return clinicDto;
        }
        public async Task<List<GetClinicDto>> GetAllAsync()
        {
            var clincis = await clinicRepository.GetAllAsync();
            var provinces = await provinceRepository.GetAllAsync();
            var cities = await cityRepository.GetAllAsync();
            var viewClinic = from pr in provinces
                             join ct in cities
                             on pr.Id equals ct.ProvinceId
                             join cln in clincis
                             on pr.Id equals cln.ProvinceId
                             select new GetClinicDto
                             {
                                 Id = cln.Id,
                                 ClinicName = cln.ClinicName!,
                                 ProvinceName = pr.ProvinceName!,
                                 CityName = ct.Name!,
                                 Address = cln.Address!,
                             };
            return mapper.Map<List<GetClinicDto>>(viewClinic);
        }
        public async Task<GetClinicDto> GetClinicDetails(int doctorId)
        {
            GetClinicDto clinicDto = new GetClinicDto();
            clinicDto.Clinics = mapper.Map<List<GetClinicDto>>(await clinicRepository.GetClinicByDoctorIdAsync(doctorId));
            clinicDto.Provinces = mapper.Map<List<ProvinceDto>>(await provinceRepository.GetAllAsync());
            clinicDto.Cities = mapper.Map<List<GetCityDto>>(await cityRepository.GetAllAsync());
            return clinicDto;
        }

    }
}

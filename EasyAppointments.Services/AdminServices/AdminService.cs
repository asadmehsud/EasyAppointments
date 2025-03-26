using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;

namespace EasyAppointments.Services.AdminServices
{
    public class AdminService(IAdminRepository adminRepository, IMapper mapper)
    {
        public async Task<List<AdminRegisterDto>> GetAllAsync() => mapper.Map<List<AdminRegisterDto>>(await adminRepository.GetAllAsync());
        public async Task<AdminRegisterDto> GetByIdAsync(int Id) => mapper.Map<AdminRegisterDto>(await adminRepository.GetByIdAsync(Id));
        public async Task<int> DeleteAsync(int Id) => await adminRepository.RemoveAsync(await adminRepository.GetByIdAsync(Id));
        public async Task<int> UpdateAsync(AdminRegisterDto adminDto) => await adminRepository.UpdateAsync(mapper.Map<Admin>(adminDto));
        public async Task<int> SaveAsync(AdminRegisterDto adminDto) => await adminRepository.SaveAsync(mapper.Map<Admin>(adminDto));
    }
}

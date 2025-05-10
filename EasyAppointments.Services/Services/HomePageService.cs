using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.DTOs.HomePageDTOs;

namespace EasyAppointments.Services.Services
{
    public class HomePageService(ISpecialityRepository specialityRepository, IDoctorRepository doctorRepository, IMapper mapper)
    {
        public async Task<ViewModelHome> GetData()
        {
            ViewModelHome vwModel = new ViewModelHome();
            vwModel.Specialities = mapper.Map<List<SpecialityDto>>(await specialityRepository.GetAllAsync());
            vwModel.Doctors = mapper.Map<List<DoctorDto>>(await doctorRepository.GetAllAsync());
            return vwModel;
        }
    }
}

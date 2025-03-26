using AutoMapper;
using EasyAppointments.Areas.Doctor.CustomClasses;
using EasyAppointments.Core.Enum;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using EasyAppointments.Services.DTOs.DoctorDTOs;

namespace EasyAppointments.Services.DoctorServices
{
    public class DoctorService(IDoctorRepository doctorRepository, IMapper mapper, IProvinceRepository provinceRepository, ICityRepository cityRepository, ISpecialityRepository specialityRepository, IClinicRepository clinicRepository)
    {
        public async Task<int> SaveAsync(DoctorDto doctorDto)
        {
            doctorDto.Status = (int)ActionType.Pending;
            doctorDto.Role=Role.Doctor;
            return await doctorRepository.SaveAsync(mapper.Map<Doctor>(doctorDto));
        }
        public async Task<int> UpdateAsync(DoctorDto doctorDto)
        {
            Doctor row = new Doctor();
            row = await doctorRepository.GetByIdAsync(doctorDto.Id);
            DoctorDto objDocDto = new DoctorDto()
            {
                FirstName = row.FirstName,
                LastName = row.LastName,
                Email = row.Email,
                Contact = row.Contact,
                CNIC = row.CNIC,
                Password = row.Password,
                Image = row.Image,
                Id = row.Id,
                Status = row.Status,
                Address = row.Address ?? doctorDto.Address,
                Province = row.Province == 0 ? doctorDto.Province : row.Province,
                City = row.City == 0 ? doctorDto.City : row.City,
                ZipCode = row.ZipCode ?? doctorDto.ZipCode,
                Speciality = doctorDto.Speciality,
                Qualifications = doctorDto.Qualifications,

            };
            var doctor = mapper.Map<Doctor>(objDocDto);
            return await doctorRepository.UpdateAsync(doctor);
        }
        public async Task<List<DoctorDto>> GetAllAsync()
        {
            var doctors = await doctorRepository.GetAllAsync();
            var cities = await cityRepository.GetAllAsync();
            var provinces = await provinceRepository.GetAllAsync();
            var medicalCenters = await clinicRepository.GetAllAsync();
            var specialities = await specialityRepository.GetAllAsync();
            var alldata = from dr in doctors
                          join pr in provinces
                        on dr.Province equals pr.Id
                          join ct in cities on pr.Id equals ct.ProvinceId
                          join mc in medicalCenters on ct.Id equals mc.CityId
                          join sp in specialities on dr.Speciality equals sp.Id
                          select new DoctorDto
                          {
                              Id = dr.Id,
                              FirstName = dr.FirstName,
                              LastName = dr.LastName,
                              Image = dr.Image,
                              Contact = dr.Contact,
                              Address = dr.Address!,
                              ActiveStatus = dr.ActiveStatus,
                              CNIC = dr.CNIC,
                              ProvinceName = pr.ProvinceName,
                              CityName = ct.Name,
                              SpecialityName = sp.Name
                          };
            return alldata.ToList();
        }

        public async Task<DoctorDto> GetByIdAsync(int Id) => mapper.Map<DoctorDto>(await doctorRepository.GetByIdAsync(Id));
        public async Task<int> ChangeStatus(int UserId, int Status)
        {
            var doctor = await doctorRepository.GetByIdAsync(UserId);
            doctor.Status = Status;
            return await doctorRepository.UpdateAsync(doctor);
        }
        public async Task<List<DoctorDto>> GetByStatusAsync(int Status) => mapper.Map<List<DoctorDto>>(await doctorRepository.GetByStatusAsync(Status));
        public async Task<bool> LoginAsync(DoctorDto doctor) => await doctorRepository.LoginAsync(mapper.Map<Doctor>(doctor)) == null ? false : true;
        public async Task<int> ChangeActiveStatus(int Id, int ActiveStatus)
        {
            var doctor = await doctorRepository.GetByIdAsync(Id);
            doctor.ActiveStatus = ActiveStatus;
            return await doctorRepository.UpdateAsync(doctor);
        }
    }
}

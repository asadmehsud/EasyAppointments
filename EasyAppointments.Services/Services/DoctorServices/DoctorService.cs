using AutoMapper;
using EasyAppointments.Areas.Doctor.CustomClasses;
using EasyAppointments.Core.Enum;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Repositories.DoctorRepositories.Interfaces;
using EasyAppointments.Services.DTOs.DoctorDTOs;

namespace EasyAppointments.Services.Services.DoctorServices
{
    public class DoctorService(IDoctorRepository doctorRepository, IMapper mapper, ISpecialityRepository specialityRepository)
    {
        public async Task<int> SaveAsync(DoctorDto doctorDto)
        {
            doctorDto.Status = (int)ActionType.Pending;
            doctorDto.Role = Role.Doctor;
            return await doctorRepository.SaveAsync(mapper.Map<Doctor>(doctorDto));
        }
        public async Task<int> UpdateAsync(DoctorDto doctorDto)
        {
            Doctor row = new Doctor();
            row = await doctorRepository.GetByIdAsync(doctorDto.Id);
            DoctorDto objDocDto = new DoctorDto()
            {
                FirstName = doctorDto.FirstName is not null ? doctorDto.FirstName : row.FirstName!,
                LastName = doctorDto.LastName is not null ? doctorDto.LastName : row.LastName!,
                UserName = doctorDto.UserName is not null ? doctorDto.UserName : row.UserName!,
                Email = doctorDto.Email is not null ? doctorDto.Email : row.Email!,
                Contact = doctorDto.Contact is not null ? doctorDto.Contact : row.Contact!,
                Password = row.Password!,
                Role = row.Role,
                Id = row.Id,
                Status = row.Status,
                ActiveStatus = row.ActiveStatus,
                CNIC = doctorDto.CNIC is not null ? doctorDto.CNIC : row.CNIC!,
                Image = doctorDto.Image is null || doctorDto.Image!.Length == 0 ? row.Image! : doctorDto.Image!,
                CNICFrontImage = doctorDto.CNICFrontImage is null || doctorDto.CNICFrontImage.Length == 0 ? row.CNICFrontImage! : doctorDto.CNICFrontImage!,
                Address = doctorDto.Address is not null ? doctorDto.Address : row.Address!,
                ZipCode = doctorDto.ZipCode is not null ? doctorDto.ZipCode : row.ZipCode!,
                Speciality = doctorDto.Speciality != 0 ? doctorDto.Speciality : row.Speciality,
                AcademicQualifications = doctorDto.AcademicQualifications is not null ? doctorDto.AcademicQualifications : row.AcademicQualifications!,
                QualificationDocuments = doctorDto.QualificationDocuments is null || doctorDto.QualificationDocuments.Length == 0 ? row.QualificationDocuments! : doctorDto.QualificationDocuments!,
            };
            var doctor = mapper.Map<Doctor>(objDocDto);
            return await doctorRepository.UpdateAsync(doctor);
        }
        public async Task<List<DoctorDto>> GetAllAsync()
        {
            var doctors = await doctorRepository.GetAllAsync();
            return mapper.Map<List<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> GetByIdAsync(int Id)
        {
            var doctor = mapper.Map<DoctorDto>(await doctorRepository.GetByIdAsync(Id));
            var speciality = await specialityRepository.GetByIdAsync(doctor.Speciality);
            doctor.SpecialityName = speciality is null ? null! : speciality.Name!;
            return doctor;
        }



        public async Task<int> ChangeStatus(int UserId, int Status)
        {
            var doctor = await doctorRepository.GetByIdAsync(UserId);
            doctor.Status = Status;
            return await doctorRepository.UpdateAsync(doctor);
        }
        public async Task<List<DoctorDto>> GetByStatusAsync(int Status) => mapper.Map<List<DoctorDto>>(await doctorRepository.GetByStatusAsync(Status));
        public async Task<int> ChangeActiveStatus(int Id, int ActiveStatus)
        {
            var doctor = await doctorRepository.GetByIdAsync(Id);
            doctor.ActiveStatus = ActiveStatus;
            return await doctorRepository.UpdateAsync(doctor);
        }
        public async Task<int> DeleteAsync(int Id)
        {
            var doctor = await doctorRepository.GetByIdAsync(Id);
            return await doctorRepository.DeleteAsync(doctor);
        }
    }
}

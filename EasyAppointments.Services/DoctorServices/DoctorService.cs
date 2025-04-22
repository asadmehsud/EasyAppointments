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
            doctorDto.Role = Role.Doctor;
            return await doctorRepository.SaveAsync(mapper.Map<Doctor>(doctorDto));
        }
        public async Task<int> UpdateAsync(DoctorDto doctorDto)
        {
            Doctor row = new Doctor();
            row = await doctorRepository.GetByIdAsync(doctorDto.Id);
            DoctorDto objDocDto = new DoctorDto()
            {
                FirstName = row.FirstName != doctorDto.FirstName ? doctorDto.FirstName : row.FirstName,
                LastName = row.LastName != doctorDto.LastName ? doctorDto.LastName : row.LastName,
                UserName = row.UserName != doctorDto.UserName ? doctorDto.UserName : row.UserName,
                Email = row.Email != doctorDto.Email ? doctorDto.Email : row.Email,
                Contact = row.Contact != doctorDto.Contact ? doctorDto.Contact : row.Contact,
                Password = row.Password!,
                Role = row.Role,
                Id = row.Id,
                Status = row.Status,
                ActiveStatus = row.ActiveStatus,
                CNIC = row.CNIC is null || row.CNIC != doctorDto.CNIC ? doctorDto.CNIC : row.CNIC,
                Image = row.Image is null || row.Image.Length == 0 || !row.Image.SequenceEqual(doctorDto.Image) ? doctorDto.Image : row.Image!,
                CNICFrontImage = row.CNICFrontImage is null || row.CNICFrontImage.Length == 0 || !row.CNICFrontImage.SequenceEqual(doctorDto.CNICFrontImage) ? doctorDto.CNICFrontImage : row.CNICFrontImage!,
                Address = row.Address is null || row.Address != doctorDto.Address ? doctorDto.Address : row.Address,
                ZipCode = row.ZipCode is null || row.ZipCode != doctorDto.ZipCode ? doctorDto.ZipCode : row.ZipCode,
                Speciality = doctorDto.Speciality == 0 || row.Speciality != doctorDto.Speciality ? doctorDto.Speciality : row.Speciality,
                AcademicQualifications = row.AcademicQualifications is null || row.AcademicQualifications != doctorDto.AcademicQualifications ? doctorDto.AcademicQualifications : row.AcademicQualifications,
                QualificationDocuments = row.QualificationDocuments is null || row.QualificationDocuments.Length == 0 || !row.QualificationDocuments.SequenceEqual(doctorDto.QualificationDocuments) ? doctorDto.QualificationDocuments : row.QualificationDocuments!,
            };
            var doctor = mapper.Map<Doctor>(objDocDto);
            return await doctorRepository.UpdateAsync(doctor);
        }
        public async Task<List<DoctorDto>> GetAllAsync()
        {
            var doctors = await doctorRepository.GetAllAsync();
            return mapper.Map<List<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> GetByIdAsync(int Id) => mapper.Map<DoctorDto>(await doctorRepository.GetByIdAsync(Id));
        public async Task<DoctorDto> GetByIdentifieAsync(string Identifier)
        {
            var doctor = mapper.Map<DoctorDto>(await doctorRepository.GetByIdentifierAsync(Identifier));
            var speciality = await specialityRepository.GetByIdAsync(doctor.Speciality);
            doctor.SpecialityName = speciality.Name!;
            return doctor;
        }

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

using EasyAppointments.Core.Enum;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.DoctorDTOs
{
    public record DoctorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        [MaxLength(11)]
        public string Contact { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        [MaxLength(15)]
        public string CNIC { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; } = default!;
        [Required(ErrorMessage = "Required")]
        public byte[] QualificationDocuments { get; set; } = Array.Empty<byte>();
        [Required(ErrorMessage = "Required")]
        public string AcademicQualifications { get; set; } = default!;
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public byte[] CNICFrontImage { get; set; } = Array.Empty<byte>();

        [Required(ErrorMessage = "Required")]
        public int Status { get; set; }
      
        [Required(ErrorMessage = "Required")]
        public string ZipCode { get; set; } = default!;

        public int Speciality { get; set; }
        public int ActiveStatus { get; set; }
        public string ProvinceName { get; set; } = default!;
        public string CityName { get; set; } = default!;
        public string SpecialityName { get; set; } = default!;
        public Role Role { get; set; } = default!;
        public IEnumerable<ProvinceDto> Provinces { get; set; } = new List<ProvinceDto>();
        public IEnumerable<GetCityDto> Cities { get; set; } = new List<GetCityDto>();
        public IEnumerable<GetClinicDto> Clinics { get; set; } = new List<GetClinicDto>();
        public IEnumerable<SpecialityDto> Specialities { get; set; } = new List<SpecialityDto>();
    }
}

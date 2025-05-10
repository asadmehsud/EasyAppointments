using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EasyAppointments.Core.Enum;
using EasyAppointments.Core.Interfaces.DoctorInterfaces;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyAppointments.Services.Services.DoctorServices
{
    public class DoctorAuthenticationService(IDoctorAuthenticationRepository doctorAuthenticationRepository, IMapper mapper, IConfiguration configuration)
    {
        public async Task<int> DoctorRegistrationAsync(DoctorRegisterDto doctorRegisterDto)
        {
            doctorRegisterDto.Role = Role.Doctor;
            return await doctorAuthenticationRepository.RegisterAsync(mapper.Map<Doctor>(doctorRegisterDto));
        }
        public async Task<(int, string)> DoctorLoginAsync(DoctorLoginDto doctorLoginDto)
        {
            var doctor = await doctorAuthenticationRepository.LoginAsync(doctorLoginDto.Identifier);
            if (doctor is not null)
            {
                var doctorByPassword = await doctorAuthenticationRepository.VerifyPasswordAsync(doctorLoginDto.Password);
                if (doctorByPassword is not null)
                {
                    var token = CreateToken(doctor);
                    return ((int)ResponseType.Success, token);
                }
                return ((int)ResponseType.InvalidPassword, null!);
            }
            return ((int)ResponseType.InvalidEmailOrContact, null)!;
        }
        private string CreateToken(Doctor doctor)
        {
            var claims = new List<Claim> { new("Role", doctor.Role.ToString()), new("DoctorId", doctor.Id.ToString()) };
            var tokenkey = configuration["Token"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenkey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptions = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptions);
            return tokenHandler.WriteToken(token);
        }
    }
}

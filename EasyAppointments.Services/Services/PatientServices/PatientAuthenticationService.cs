using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EasyAppointments.Core.Enum;
using EasyAppointments.Core.Interfaces.PatientInterfaces;
using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.PatientDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyAppointments.Services.Services.PatientServices
{
    public class PatientAuthenticationService(IPatientAuthenticationRepository patientAuthenticationRepository, IMapper mapper, IConfiguration configuration)
    {
        public async Task<int> PatientRegistrationAsync(PatientRegisterDto patientRegisterDto)
        {
            patientRegisterDto.Role = Role.Patient;
            return await patientAuthenticationRepository.RegisterAsync(mapper.Map<Patient>(patientRegisterDto));
        }
        public async Task<(int, string)> PatientLoginAsync(PatientLoginDto patientLoginDto)
        {
            var patient = await patientAuthenticationRepository.LoginAsync(patientLoginDto.Identifier);
            if (patient is not null)
            {
                var patientByPassword = await patientAuthenticationRepository.VerifyPasswordAsync(patientLoginDto.Password);
                if (patientByPassword is not null)
                {
                    var token = CreateToken(patient);
                    return ((int)ResponseType.Success, token!);
                }
                return ((int)ResponseType.InvalidPassword, null!);
            }
            return ((int)ResponseType.InvalidEmailOrContact, null!);
        }
        private string CreateToken(Patient patient)
        {
            var claims = new List<Claim>
            {
            new("Role",patient.Role.ToString()),
            new("PatientId",patient.PatientId.ToString())
            };
            var tokenKey = configuration["Token"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}

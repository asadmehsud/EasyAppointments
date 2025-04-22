using AutoMapper;
using EasyAppointments.Core.Enum;
using EasyAppointments.Core.Interfaces.PatientInterfaces;
using EasyAppointments.Data.Entities.PatientEntities;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.Authentication;
using EasyAppointments.Services.DTOs.PatientDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyAppointments.Services.PatientServices
{
    public class PatientAuthenticationService(IPatientAuthenticationRepository patientAuthenticationRepository, IMapper mapper, CookiesService cookiesService, IConfiguration configuration)
    {
        public async Task<int> PatientRegistrationAsync(PatientRegisterDto patientRegisterDto)
        {
            patientRegisterDto.Role = Role.Patient;
            return await patientAuthenticationRepository.RegisterAsync(mapper.Map<Patient>(patientRegisterDto));
        }
        public async Task<int> PatientLoginAsync(PatientLoginDto patientLoginDto)
        {
            var patient = await patientAuthenticationRepository.LoginAsync(patientLoginDto.Identifier);
            if (patient is not null)
            {
                var patientByPassword = await patientAuthenticationRepository.VerifyPasswordAsync(patientLoginDto.Password);
                if (patientByPassword is not null)
                {
                    //  var token = CreateToken(admin);
                    cookiesService.AppendCookie(CookiesKey.AuthToken!, "jwtToken", DateTime.UtcNow.AddDays(1));
                    return (int)ResponseType.Success;
                }
                return (int)ResponseType.InvalidPassword;
            }
            return (int)ResponseType.InvalidEmailOrContact;
        }
        private string CreateToken(Patient patient)
        {
            var claims = new List<Claim>
            {
            new(ClaimTypes.Role,patient.Role.ToString()),
            new(ClaimTypes.NameIdentifier,patient.PatientId.ToString())
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

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyAppointments.Services.Services.AdminServices
{
    public class AdminAuthenticationService(IAdminAuthenticationRepository adminAuthenticationRepository, IMapper mapper, IConfiguration configuration)
    {
        public async Task<int> AdminRegistrationAsync(AdminRegisterDto adminRegisterDto)
        {
            return await adminAuthenticationRepository.RegisterAsync(mapper.Map<Admin>(adminRegisterDto));
        }
        public async Task<(int, string)> AdminLoginAsync(AdminLoginDto adminLoginDto)
        {
            var admin = await adminAuthenticationRepository.LoginAsync(adminLoginDto.AdminIdentifier);
            if (admin is not null)
            {
                var adminByPassword = await adminAuthenticationRepository.VerifyPasswordAsync(adminLoginDto.Password);
                if (adminByPassword is not null)
                {
                    var token = CreateToken(admin);
                    return ((int)ResponseType.Success, token);
                }
                return ((int)ResponseType.InvalidPassword, null!);
            }
            return ((int)ResponseType.InvalidEmailOrContact, null!);
        }
        private string CreateToken(Admin admin)
        {
            var claims = new List<Claim>
            {
                new("Role",admin.Role.ToString()),
                new("AdminId",admin.Id.ToString()),
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

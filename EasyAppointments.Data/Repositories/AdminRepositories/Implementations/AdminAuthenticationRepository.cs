using EasyAppointments.Core.Interfaces.AdminInterfaces;
using EasyAppointments.Data.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;

namespace EasyAppointments.Data.Repositories.AdminRepositories.Implementations
{
    public class AdminAuthenticationRepository(DbEasyAppointmentsContext context) : IAdminAuthenticationRepository
    {
        public async Task<Admin> LoginAsync(string AdminIdentifier)
        {
            var admin = await context.Admins
               .FirstOrDefaultAsync(a => a.UserName == AdminIdentifier || a.Email == AdminIdentifier || a.Contact == AdminIdentifier);
            return admin is null ? null! : admin;
        }
        public async Task<Admin> VerifyPasswordAsync(string Password)
        {
            var admin = await context.Admins
               .FirstOrDefaultAsync(a => a.Password == Password);
            if (admin is null)
            {
                return null!;
            }
            return admin;
        }

        public async Task<int> RegisterAsync(Admin admin)
        {
            var data = await context.Admins.FirstOrDefaultAsync(a => a.Email == admin.Email);
            if (data is null)
            {
                await context.Admins.AddAsync(admin);
                return await context.SaveChangesAsync();
            }
            return (int)ResponseType.RecordAlreadyExist;
        }
    }
}

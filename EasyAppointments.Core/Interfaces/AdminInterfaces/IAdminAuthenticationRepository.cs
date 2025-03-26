using EasyAppointments.Data.Entities.AdminEntities;

namespace EasyAppointments.Core.Interfaces.AdminInterfaces
{
    public interface IAdminAuthenticationRepository
    {
        Task<int> RegisterAsync(Admin admin);
        Task<Admin> LoginAsync(string AdminIdentifier);
        Task<Admin> VerifyPasswordAsync(string Password);
    }
}

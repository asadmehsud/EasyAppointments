using EasyAppointments.Data.Entities.AdminEntities;

namespace EasyAppointments.Core.Interfaces.AdminInterfaces
{
    public interface ISpecialityRepository
    {
        Task<int> SaveAsync(Speciality speciality);
        Task<int> UpdateAsync(Speciality speciality);
        Task<int> RemoveAsync(Speciality speciality);
        Task<Speciality> GetByIdAsync(int id);
        Task<List<Speciality>> GetAllAsync();
    }
}

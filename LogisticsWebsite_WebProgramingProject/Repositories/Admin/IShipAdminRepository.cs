using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
    public interface IShipAdminRepository
    {
        Task<IEnumerable<Ship>> GetAllAsync();
        Task<Ship> GetByIdAsync(int id);
        Task AddAsync(Ship ship);
        Task UpdateAsync(Ship ship);
        Task DeleteAsync(int id);
    }
}

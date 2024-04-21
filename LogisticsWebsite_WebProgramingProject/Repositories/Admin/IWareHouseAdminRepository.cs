using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
    public interface IWareHouseAdminRepository
    {
        Task<IEnumerable<WareHouse>> GetAllAsync();
        Task<WareHouse> GetByIdAsync(int id);
        Task AddAsync(WareHouse wareHouse);
        Task UpdateAsync(WareHouse wareHouse);
        Task DeleteAsync(int id);
    }
}

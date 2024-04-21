using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
    public interface IContainerAdminRepository
    {
        Task<IEnumerable<Container>> GetAllAsync();
        Task<Container> GetByIdAsync(int id);
        Task AddAsync(Container container);
        Task UpdateAsync(Container container);
        Task DeleteAsync(int id); 
    }
}

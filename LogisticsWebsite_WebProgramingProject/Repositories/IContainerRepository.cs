using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public interface  IContainerRepository
    {
        Task<IEnumerable<Container>> GetAllAsync();
        Task<Container> GetByIdAsync(int Id);
        Task AddAsync(Container container);
    }
}

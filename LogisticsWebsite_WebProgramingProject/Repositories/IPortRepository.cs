using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public interface IPortRepository
    {
        Task<IEnumerable<Port>> GetAllAsync();
        Task<Port> GetByIdAsync(int Id);
    }
}

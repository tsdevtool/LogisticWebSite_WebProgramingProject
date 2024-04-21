using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public interface ITrackingRepository
    {
        Task<IEnumerable<Tracking>> GetAllAsync();
        Task<Tracking> GetByIdAsync(int scheid);
        Task AddAsync(Tracking tracking);
    }
}

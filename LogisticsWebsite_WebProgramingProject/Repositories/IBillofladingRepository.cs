using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public interface IBillofladingRepository
    {
        Task<IEnumerable<BillOfLading>> GetAllAsync();
        Task<BillOfLading> GetByIdAsync(int BillId);
        Task AddAsync(BillOfLading billOfLading);
    }
}

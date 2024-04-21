using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
    public interface IScheduleAdminRepository
    {
		Task<IEnumerable<Schedule>> GetAllAsync();
		Task<Schedule> GetByIdAsync(int id);
/*		Task<Schedule> GetByBillofladingIdAsync(int id);*/
		Task AddAsync(Schedule sche);
		Task UpdateAsync(Schedule sche);
		Task DeleteAsync(int id);
        Task<IEnumerable<Schedule>> GetByPortIDAsync(int id);
        Task<IEnumerable<Schedule>> GetByShipIDAsync(int id);
    }
}

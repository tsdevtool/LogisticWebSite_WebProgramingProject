using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAllAsync();
		Task<IEnumerable<Schedule>> GetAsync();
		Task<Schedule> GetByIdAsync(int scheid);
    }
}

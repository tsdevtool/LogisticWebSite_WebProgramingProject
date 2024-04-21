using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public interface ITrackingAdminRepository
	{
		Task<IEnumerable<Tracking>> GetAllAsync();
		Task<Tracking> GetByIdAsync(int id);
		Task<Tracking> GetByBillIdAsync(int id);
		Task UpdateAsync(Tracking tracking);
	}
}

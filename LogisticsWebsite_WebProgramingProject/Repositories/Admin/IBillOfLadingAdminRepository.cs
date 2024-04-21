using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public interface IBillOfLadingAdminRepository
	{
		Task<IEnumerable<BillOfLading>> GetAllAsync();
		Task<BillOfLading> GetByBillOfLadingIDAsync(int id);
		Task<List<BillOfLading>> GetByScheduleIDAsync(int id);
	}
}

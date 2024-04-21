using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public interface ICostsIncurredAdminRepository
	{
		Task<IEnumerable<CostsIncurred>> GetAllAsync();
		Task<CostsIncurred> GetByIdAsync(int id);
		Task<CostsIncurred> GetByBillofLadingIdAsync(int id);
		Task AddAsync(CostsIncurred costsIncurred);
		Task UpdateAsync(CostsIncurred costsIncurred);
		/*Task DeleteAsync(int id);*///không xóa
	}
}

using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public interface IPortAdminRepository
	{
		Task<IEnumerable<Port>> GetAllAsync();
		Task<Port> GetByIdAsync(int id);
		Task AddAsync(Port port);
		Task UpdateAsync(Port port);
		Task DeleteAsync(int id);
	}
}

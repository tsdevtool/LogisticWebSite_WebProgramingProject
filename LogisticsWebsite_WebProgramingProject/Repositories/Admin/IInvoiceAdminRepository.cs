using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public interface IInvoiceAdminRepository
	{
		Task<IEnumerable<Invoice>> GetAllAsync();
		Task<Invoice> GetByIdAsync(int id);
		Task AddAsync(Invoice invoice);
		Task UpdateAsync(Invoice invoice);
	}
}

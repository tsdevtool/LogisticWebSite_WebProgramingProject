using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public class EFInvoiceAdminRepository : IInvoiceAdminRepository
	{
		public readonly LogisticsContext _context;
		public EFInvoiceAdminRepository(LogisticsContext context)
		{
			_context = context;
		}
		public async Task AddAsync(Invoice invoice)
		{
			_context.Invoices.Add(invoice);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Invoice>> GetAllAsync()
		{
			return await _context.Invoices.ToListAsync();
		}

		public async Task<Invoice> GetByIdAsync(int id)
		{
			return await _context.Invoices.FindAsync(id);
		}

		public async Task UpdateAsync(Invoice invoice)
		{
			_context.Invoices.Update(invoice);
			await _context.SaveChangesAsync();
		}
	}
}

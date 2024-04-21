using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public class EFCostsIncurredAdminRepository : ICostsIncurredAdminRepository
	{
		private readonly LogisticsContext _context;
		public EFCostsIncurredAdminRepository(LogisticsContext context)
		{
			_context = context;
		}

		public async Task AddAsync(CostsIncurred costsIncurred)
		{
			_context.Add(costsIncurred);
			await _context.SaveChangesAsync();
		}

	/*	public async Task DeleteAsync(int id)
		{
			var cost = await _context.CostsIncurreds.FindAsync(id);
			_context.CostsIncurreds.Remove(cost);
			await _context.SaveChangesAsync();
		}*/ //mặc định cái này sẽ không xóa

		public async Task<IEnumerable<CostsIncurred>> GetAllAsync()
		{
			return await _context.CostsIncurreds.ToListAsync();
		}

		public async Task<CostsIncurred> GetByBillofLadingIdAsync(int id)
		{
			return await _context.CostsIncurreds.FirstOrDefaultAsync(p=>p.BillId == id);
		}

		public async Task<CostsIncurred> GetByIdAsync(int id)
		{
			return await _context.CostsIncurreds.FindAsync(id);
		}

		public async Task UpdateAsync(CostsIncurred costsIncurred)
		{
			_context.CostsIncurreds.Update(costsIncurred);
			await _context.SaveChangesAsync();
		}
	}
}

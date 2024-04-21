using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public class EFBillOfLadingAdminRepository : IBillOfLadingAdminRepository
	{
		private readonly LogisticsContext _context;
		public EFBillOfLadingAdminRepository(LogisticsContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<BillOfLading>> GetAllAsync()
		{
			return await _context.BillOfLadings.ToListAsync();
		}
		public async Task<BillOfLading> GetByBillOfLadingIDAsync(int id)
		{
			return await _context.BillOfLadings.FirstOrDefaultAsync(p=>p.BillId == id);
		}

		public async Task<List<BillOfLading>> GetByScheduleIDAsync(int id)
		{
			return await _context.BillOfLadings.Where(p => p.ScheduleId == id).ToListAsync();
		}
	}
}

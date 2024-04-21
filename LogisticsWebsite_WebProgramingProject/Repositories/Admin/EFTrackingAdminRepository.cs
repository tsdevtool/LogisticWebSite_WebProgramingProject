using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public class EFTrackingAdminRepository : ITrackingAdminRepository
	{
		private readonly LogisticsContext _context;
		public EFTrackingAdminRepository (LogisticsContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Tracking>> GetAllAsync()
		{
			return await _context.Trackings.ToListAsync();
		}

		public async Task<Tracking> GetByBillIdAsync(int id)
		{
			return await _context.Trackings.FirstOrDefaultAsync(p => p.BillId == id);
		}

		public async Task<Tracking> GetByIdAsync(int id)
		{
			return await _context.Trackings.FirstOrDefaultAsync(x => x.TrackingId == id);
		}

		public async Task UpdateAsync(Tracking tracking)
		{
			_context.Update(tracking);
			await _context.SaveChangesAsync();
		}
	}
}

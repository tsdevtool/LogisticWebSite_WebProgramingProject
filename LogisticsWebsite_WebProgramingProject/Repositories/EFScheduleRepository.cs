using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public class EFScheduleRepository : IScheduleRepository
    {
        private readonly LogisticsContext _context;
        public EFScheduleRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
			DateOnly daygo = DateOnly.FromDateTime(DateTime.Now.AddDays(5));
			//thêm điều kiện select theo lịch trình mà khách chọn
			var sche = await _context.Schedules.Where(p => p.DayGo >= daygo).Include(p => p.Ship).ToListAsync();
			return sche;
		}
		public async Task<IEnumerable<Schedule>> GetAsync()
		{
			var sche = await _context.Schedules.Include(p => p.Ship).ToListAsync();
			return sche;
		}
		public async Task<Schedule> GetByIdAsync(int id)
        {
          return await _context.Schedules.Include(p=>p.BillOfLadings).FirstOrDefaultAsync(p=>p.ScheduleId==id);
           
        }
    }
}

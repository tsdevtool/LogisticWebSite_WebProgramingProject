using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public class EFScheduleAdminRepository : IScheduleAdminRepository
	{
		private readonly LogisticsContext _context;
		public EFScheduleAdminRepository(LogisticsContext context)
		{
			_context = context;
		}
		public async Task AddAsync(Schedule sche)
		{
            _context.Schedules.Add(sche);
			await _context.SaveChangesAsync();

        }

		public async Task DeleteAsync(int id)
		{
            var SCH = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(SCH);
            await _context.SaveChangesAsync();
        }

		public async Task<IEnumerable<Schedule>> GetAllAsync() //dùng để xuất tất cả lịch trình, cho user chọn và admin quản lý
		{
			var sche = await _context.Schedules.Include(p=>p.Ship).ToListAsync();
			return sche;

		}


		public async Task<Schedule> GetByIdAsync(int id)
		{
			return await _context.Schedules.FirstOrDefaultAsync(p=>p.ScheduleId==id);
		}
        public async Task<IEnumerable<Schedule>> GetByPortIDAsync(int id)//lấy những lịch trình có cùng mã Port mà mình muốn xóa để xóa lịch trình
        {
            var schedules = await _context.Schedules.Where(p => p.Pod == id || p.Pol == id).ToListAsync();
            return schedules;
        }
        public async Task<IEnumerable<Schedule>> GetByShipIDAsync(int id) //lấy những lịch trình có cùng mã tàu mà mình muốn xóa để xóa lịch trình
        {
            var schedules = await _context.Schedules.Where(p => p.ShipId == id).ToListAsync();
            return schedules;
        }
        public async Task UpdateAsync(Schedule sche)
		{
			_context.Schedules.Update(sche);
			await _context.SaveChangesAsync();
		}
	}
}

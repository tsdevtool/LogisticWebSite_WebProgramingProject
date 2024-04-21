using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public class EFBillofladingRepository : IBillofladingRepository
    {

        private readonly LogisticsContext _context;
        public EFBillofladingRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BillOfLading>> GetAllAsync()
        {
            return await _context.BillOfLadings.Include(p => p.Schedule).ToListAsync();
        }
        public async Task<BillOfLading> GetByIdAsync(int id)
        {
            return await _context.BillOfLadings.Include(p => p.Schedule).FirstOrDefaultAsync(p => p.ScheduleId == id);
        }
        public async Task AddAsync(BillOfLading billOfLading)
        {
            _context.BillOfLadings.Add(billOfLading);
            await _context.SaveChangesAsync();
        }
    }
}


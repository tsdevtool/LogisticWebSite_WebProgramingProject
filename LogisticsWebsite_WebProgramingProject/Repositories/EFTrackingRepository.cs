using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public class EFTrackingRepository : ITrackingRepository
    {
        private readonly LogisticsContext _context;
        public EFTrackingRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tracking>> GetAllAsync()
        {
            return await _context.Trackings.ToListAsync();
        }
        public async Task<Tracking> GetByIdAsync(int id)
        {
            return await _context.Trackings.FindAsync(id);
        }
        public async Task AddAsync(Tracking tracking)
        {
            _context.Trackings.Add(tracking);
            await _context.SaveChangesAsync();
        }
    }
}

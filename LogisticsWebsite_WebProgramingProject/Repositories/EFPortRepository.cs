using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public class EFPortRepository :IPortRepository 
    {
        private readonly LogisticsContext _context;
        public EFPortRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Port>> GetAllAsync()
        {
            return await _context.Ports.ToListAsync();
        }
        public async Task<Port> GetByIdAsync(int id)
        {
         return await _context.Ports.FindAsync(id);
        }
    }
}

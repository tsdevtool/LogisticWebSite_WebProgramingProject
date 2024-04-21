using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public class EFContainerRepository : IContainerRepository
    {
        private readonly LogisticsContext _context;
        public EFContainerRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Container>> GetAllAsync()
        {
            return await _context.Containers.Include(p => p.BillOfLadings).ToListAsync();
        }
        public async Task<Container> GetByIdAsync(int id)
        {
            return await _context.Containers.Include(p => p.BillOfLadings).FirstOrDefaultAsync(p => p.ContainerId == id);
        }
        public async Task AddAsync(Container container)
        {
            _context.Containers.Add(container);
            await _context.SaveChangesAsync();
        }
    }
}

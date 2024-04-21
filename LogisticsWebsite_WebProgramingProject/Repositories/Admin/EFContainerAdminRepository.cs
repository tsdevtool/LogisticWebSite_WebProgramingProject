using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
    public class EFContainerAdminRepository : IContainerAdminRepository
    {
        private readonly LogisticsContext _context;
        public EFContainerAdminRepository(LogisticsContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Container container)
        {
            _context.Add(container);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dele = await _context.Containers.FindAsync(id);
            _context.Containers.Remove(dele);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Container>> GetAllAsync()
        {
            return await _context.Containers.ToListAsync();
        }

        public async Task<Container> GetByIdAsync(int id)
        {
            return await _context.Containers.FirstOrDefaultAsync(p=>p.ContainerId == id);
        }

        public async Task UpdateAsync(Container container)
        {
            _context.Update(container);
            await _context.SaveChangesAsync();
        }
    }
}

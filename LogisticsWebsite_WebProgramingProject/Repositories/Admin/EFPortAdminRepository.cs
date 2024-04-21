using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public class EFPortAdminRepository : IPortAdminRepository
	{
		private readonly LogisticsContext _context;
		public EFPortAdminRepository(LogisticsContext context)
		{
			_context = context;
		}

        public async Task AddAsync(Port port)
        {
            _context.Ports.Add(port);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var dele =  await _context.Ports.FindAsync(id);
            _context.Ports.Remove(dele);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Port>> GetAllAsync()
        {
            return await _context.Ports.ToListAsync();
        }

        public async Task<Port> GetByIdAsync(int id)
		{
			return await _context.Ports.FirstOrDefaultAsync(p => p.PortId == id);
        }

        public async Task UpdateAsync(Port port)
        {
            _context.Ports.Update(port);
            await _context.SaveChangesAsync();
        }
    }
}

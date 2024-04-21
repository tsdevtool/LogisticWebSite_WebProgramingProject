using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
    
    public class EFShipAdminRepository : IShipAdminRepository
    {
        private readonly LogisticsContext _context;
        public EFShipAdminRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Ship ship)
        {
            _context.Ships.Add(ship);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sh = _context.Ships.FirstOrDefault(p=>p.ShipId == id);
            if(sh != null)
            {
				_context.Ships.Remove(sh);
				await _context.SaveChangesAsync();
			}
            else
            {
                throw new Exception("Không tìm thấy");
            }
          
        }

        public async Task<IEnumerable<Ship>> GetAllAsync()
        {
            return await _context.Ships.ToListAsync();
        }

        public async Task<Ship> GetByIdAsync(int id)
        {
            var ship =  await _context.Ships.FirstOrDefaultAsync(p=>p.ShipId == id);
            return ship;
        }

        public async Task UpdateAsync(Ship ship)
        {
            _context.Ships.Update(ship);
            await _context.SaveChangesAsync();
        }


    }
}

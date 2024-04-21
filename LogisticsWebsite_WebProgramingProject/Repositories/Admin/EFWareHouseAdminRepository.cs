using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
    public class EFWareHouseAdminRepository : IWareHouseAdminRepository
    {
        public readonly LogisticsContext _context;
        public EFWareHouseAdminRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task AddAsync(WareHouse wareHouse)
        {
            _context.WareHouses.Add(wareHouse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var wh = await _context.WareHouses.FirstOrDefaultAsync(p => p.WhareHouseId == id);
            _context.WareHouses.Remove(wh);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WareHouse>> GetAllAsync()
        {
            return await _context.WareHouses.ToListAsync();
        }

        public async Task<WareHouse> GetByIdAsync(int id)
        {
            return await _context.WareHouses.FirstOrDefaultAsync(p => p.WhareHouseId == id);
        }

        public async Task UpdateAsync(WareHouse wareHouse)
        {
            _context.WareHouses.Update(wareHouse);
            await _context.SaveChangesAsync();
        }
    }
}

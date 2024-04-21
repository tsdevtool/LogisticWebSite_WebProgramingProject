using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public class EFBokingWareHouseRepository : IBookingWareHouseRepository
    {
        private readonly LogisticsContext _context;
        public EFBokingWareHouseRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookingWareHouse>> GetAllAsync()
        {
            return await _context.BookingWareHouses.ToListAsync();
        }
        public async Task<BookingWareHouse> GetByIdAsync(int no)
        {
            return await _context.BookingWareHouses.Include(p=>p.WhareHouse).FirstOrDefaultAsync(p=>p.WhareHouseId == no);
        }
        public async Task AddAsync(BookingWareHouse bookingWareHouse)
        {
            _context.BookingWareHouses.Add(bookingWareHouse);
            await _context.SaveChangesAsync();
        }
    }
}

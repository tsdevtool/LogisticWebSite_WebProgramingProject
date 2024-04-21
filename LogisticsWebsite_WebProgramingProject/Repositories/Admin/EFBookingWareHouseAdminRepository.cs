
using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public class EFBookingWareHouseAdminRepository : IBookingWareHouseAdminRepository
	{
		private readonly LogisticsContext _context;
		public EFBookingWareHouseAdminRepository(LogisticsContext context)
		{
			_context = context;
		}

        public async Task AddAsync(BookingWareHouse bookingWareHouse)
        {
            _context.BookingWareHouses.Add(bookingWareHouse);
			await _context.SaveChangesAsync();
        }

		public async Task DeleteAsync(int id)
		{
			var bkwh = _context.BookingWareHouses.FirstOrDefault(p => p.No == id);
			if (bkwh != null)
			{
				_context.BookingWareHouses.Remove(bkwh);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Không tồn tại trong CSDL");
			}
		}

		public async Task<IEnumerable<BookingWareHouse>> GetAllAsync()
        {
			return await _context.BookingWareHouses.ToListAsync();
        }

        public async Task<BookingWareHouse> GetByIdAsync(int id)
        {
			return await _context.BookingWareHouses.FirstOrDefaultAsync(p=>p.No == id);
        }

        public async Task<BookingWareHouse> GetByIdBillAsync(int id)
        {
			return await _context.BookingWareHouses.FirstOrDefaultAsync(p=>p.BillId == id);
		}

        public async Task<IEnumerable<BookingWareHouse>> GetByWareHouseIDAsync(int id)
		{
			return await _context.BookingWareHouses.Where(p => p.WhareHouseId == id).ToListAsync();
			
		}

        public async Task<bool> UpdateAsync(BookingWareHouse bookingWareHouse)
        {
			_context.BookingWareHouses.Update(bookingWareHouse);
			await _context.SaveChangesAsync();
			return true;
        }
    }
}

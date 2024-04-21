using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;   
namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public class EFbookinginfomationRepository : IBookinginfomationRepository
    {
        private readonly LogisticsContext _context;
        public EFbookinginfomationRepository(LogisticsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookingInfomation>> GetAllAsync()
        {
            return await _context.BookingInfomations.Include(p=>p.BillOfLadings).ToListAsync();
        }
        public async Task<BookingInfomation> GetByIdAsync(int bookingno)
        {
            return await _context.BookingInfomations.Include(p => p.BillOfLadings).FirstOrDefaultAsync(p => p.BookingNo == bookingno);
        }
        public async Task AddAsync(BookingInfomation bookingInfomation)
        {
            _context.BookingInfomations.Add(bookingInfomation);
            await _context.SaveChangesAsync();
        }


    }
}

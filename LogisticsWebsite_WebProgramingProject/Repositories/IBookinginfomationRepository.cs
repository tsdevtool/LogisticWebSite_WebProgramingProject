using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public interface IBookinginfomationRepository
    {
        Task<IEnumerable<BookingInfomation>> GetAllAsync();
        Task<BookingInfomation> GetByIdAsync(int BookingNo);
        Task AddAsync(BookingInfomation bookingInfomation);
    }
}

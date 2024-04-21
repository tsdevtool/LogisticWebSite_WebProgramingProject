using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories
{
    public interface IBookingWareHouseRepository
    {
        Task<IEnumerable<BookingWareHouse>> GetAllAsync();
        Task<BookingWareHouse> GetByIdAsync(int wharehouseID);
        Task AddAsync(BookingWareHouse bookingWareHouse);
    }
}

using LogisticsWebsite_WebProgramingProject.Models;

namespace LogisticsWebsite_WebProgramingProject.Repositories.Admin
{
	public interface IBookingWareHouseAdminRepository
	{
		Task<IEnumerable<BookingWareHouse>> GetByWareHouseIDAsync(int id);
        Task DeleteAsync(int id);
        Task<IEnumerable<BookingWareHouse>> GetAllAsync();
        Task<BookingWareHouse> GetByIdAsync(int id);
        Task AddAsync(BookingWareHouse bookingWareHouse);
        Task<bool> UpdateAsync(BookingWareHouse bookingWareHouse);
        Task<BookingWareHouse> GetByIdBillAsync(int id);
    }
}

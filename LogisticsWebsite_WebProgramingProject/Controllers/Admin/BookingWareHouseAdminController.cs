using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{

	public class BookingWareHouseAdminController : Controller
	{
		private readonly IBookingWareHouseAdminRepository _IbookingWareHouseRepository;
		private readonly IBillOfLadingAdminRepository _IBillOfLading;
		private readonly IWareHouseAdminRepository _wareHouseRepository;
		// private readonly 
		public BookingWareHouseAdminController(IBookingWareHouseAdminRepository ibookingWareHouseRepository, IBillOfLadingAdminRepository billOfLading, IWareHouseAdminRepository wareHouseRepository)
		{
			_IbookingWareHouseRepository = ibookingWareHouseRepository;
			_IBillOfLading = billOfLading;
			_wareHouseRepository = wareHouseRepository;
		}

		public async Task<IActionResult> Index()
		{
			var booking = await _IbookingWareHouseRepository.GetAllAsync();
			return View(booking);
		}
		public async Task<IActionResult> SelectAdd()
		{
			var Listbill = await _IBillOfLading.GetAllAsync(); // select tất cả billoflading

			return View(Listbill);
		}
		public async Task<IActionResult> Add(int id)
		{
			var model = new LogisticsWebsite_WebProgramingProject.Models.BookingWareHouse();
			model.BillId = id;
			model.Dayin = DateOnly.FromDateTime(DateTime.Today.Date);
			var wh = await _wareHouseRepository.GetAllAsync();
			ViewBag.WarehouseList = wh.Select(w => new SelectListItem
			{
				Value = w.WhareHouseId.ToString(),
				Text = $"{w.Price} - {(w.Type ? "Reefer Container" : "Not Reefer Container")}"
			});
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Add(BookingWareHouse bookingWareHouse)
		{
			await _IbookingWareHouseRepository.AddAsync(bookingWareHouse);
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int id)
		{
			var wh = await _IbookingWareHouseRepository.GetByIdAsync(id);
			if (wh == null)
			{
				return NotFound();
			}

			return View(wh);
		}


		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _IbookingWareHouseRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
		{
			var bookingWareHouse = await _IbookingWareHouseRepository.GetByIdAsync(id);
			if (bookingWareHouse == null)
			{
				return NotFound();
			}
			var wh = await _wareHouseRepository.GetAllAsync();
			ViewBag.WarehouseList = wh.Select(w => new SelectListItem
			{
				Value = w.WhareHouseId.ToString(),
				Text = $"{w.Price} - {(w.Type ? "Reefer Container" : "Not Reefer Container")}"
			});
			return View(bookingWareHouse);

		}
		// Xử lý cập nhật sản phẩm
		[HttpPost]
		public async Task<IActionResult> Update(int id, BookingWareHouse bookingWareHouse)
		{

			var existingBKinf = await _IbookingWareHouseRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync

			// Cập nhật các thông tin khác của sản phẩm
			existingBKinf.WhareHouseId = bookingWareHouse.WhareHouseId;
			existingBKinf.Dayin = bookingWareHouse.Dayin;

			if (await _IbookingWareHouseRepository.UpdateAsync(existingBKinf)==true)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(bookingWareHouse);
		}
	}
}

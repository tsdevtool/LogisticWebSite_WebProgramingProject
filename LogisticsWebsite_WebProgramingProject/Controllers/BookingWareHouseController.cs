using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticsWebsite_WebProgramingProject.Controllers
{
    [Authorize]
    public class BookingWareHouseController : Controller
    {
        private readonly IBookingWareHouseAdminRepository _IbookingWareHouseRepository;
        private readonly IBillOfLadingAdminRepository _IBillOfLadingrepository;
        private readonly IWareHouseAdminRepository _wareHouseRepository;
        // private readonly 
        public BookingWareHouseController(IBookingWareHouseAdminRepository ibookingWareHouseRepository, IBillOfLadingAdminRepository billOfLading, IWareHouseAdminRepository wareHouseRepository)
        {
            _IbookingWareHouseRepository = ibookingWareHouseRepository;
            _IBillOfLadingrepository = billOfLading;
            _wareHouseRepository = wareHouseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {

            var model = new LogisticsWebsite_WebProgramingProject.Models.BookingWareHouse();
            var wh = await _wareHouseRepository.GetAllAsync();
            ViewBag.WarehouseList = wh.Select(w => new SelectListItem
            {
                Value = w.WhareHouseId.ToString(),
                Text = $"{w.Price} - {(w.Type ? "Reefer" : "Dry")}"
            });
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BookingWareHouse BookingWarehouse)
        {
            try
            {
               
                    var bookingWarehouse = new BookingWareHouse
                    {
                        Dayin = DateOnly.FromDateTime(DateTime.Today.Date),
                        WhareHouseId = BookingWarehouse.WhareHouseId,
                        BillId = BookingWarehouse.BillId
                    };

                    await _IbookingWareHouseRepository.AddAsync(bookingWarehouse);

                    return RedirectToAction("Index", "Home");
                
                
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Error", "Home");
            }
        }
    }
}

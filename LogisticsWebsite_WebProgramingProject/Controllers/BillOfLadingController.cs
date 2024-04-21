using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LogisticsWebsite_WebProgramingProject.Controllers
{
    [Authorize]
    public class BillOfLadingController : Controller
    {
        private readonly LogisticsContext _context;
        private readonly IBillofladingRepository _billOfLading;
        private readonly IBookinginfomationRepository _bookinginfomation;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IContainerRepository _container;
        private readonly IScheduleRepository _scheduleReponsitory;
        private readonly ITrackingRepository _tracking;
        private readonly ILogger<BillOfLadingController> _logger;
        public BillOfLadingController(LogisticsContext context, IContainerRepository container, IScheduleRepository scheduleReponsitory,
            IBookinginfomationRepository bookinginfomation, UserManager<ApplicationUser> userManager, ITrackingRepository tracking, ILogger<BillOfLadingController> logger)
        {
            _context = context;
            _container = container;
            _scheduleReponsitory = scheduleReponsitory;
            _userManager = userManager;
            _bookinginfomation = bookinginfomation;
            _tracking = tracking;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateBillOfLading()
        {
            var bookingInfos = await _bookinginfomation.GetAllAsync();
            ViewBag.BookingNo = bookingInfos.LastOrDefault()?.BookingNo; 

          
            var containers = await _container.GetAllAsync();

            var containerSelectList = containers.Select(p => new SelectListItem
            {
                Value = p.ContainerId.ToString(),
                Text = $"Container - {p.ContainerSize} - {(p.Type ? "reefer " : "dry")}"
            }).ToList();
            var schedules = await _scheduleReponsitory.GetAllAsync();
            var scheduleOptions = schedules.Select(s => new
            {
                ScheduleId = s.ScheduleId,
                DisplayText = $"{s.DayGo.ToShortDateString()} - Price: {s.Price}$" // Kết hợp DayGo và Price
            }).ToList();

            ViewBag.Schedules = new SelectList(scheduleOptions, "ScheduleId", "DisplayText");
            ViewBag.ContainerSelectList = containerSelectList;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBillOfLading(BillOfLading billOfLading)
        {
            try
            {
                _context.BillOfLadings.Add(billOfLading);
                await _context.SaveChangesAsync();

                // Tạo một đối tượng Tracking và thiết lập các thuộc tính của nó
                var tracking = new Tracking
                {
                    Status = "Comingsoon", // Thay "YourStatusHere" bằng trạng thái bạn muốn đặt
                    BillId = billOfLading.BillId // Sử dụng BillOfLadingId từ đối tượng billOfLading mới được tạo
                };

               
                _context.Trackings.AddAsync(tracking);
                await _context.SaveChangesAsync(); 

                return RedirectToAction("Success", new { billId = billOfLading.BillId });
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");

                Console.WriteLine($"Error in CreateBillOfLading: {ex.Message}");

                return View(billOfLading);
            }
        }

        public IActionResult Success(int billId)
        {

            return View(billId);
        }

        public IActionResult Details(int? id)
        {


            try
            {
                var billOfLading = _context.BillOfLadings
                    .Include(b => b.BookingNoNavigation)
                        .ThenInclude(b => b.BillOfLadings)
                    .Include(b => b.Container)
                    .Include(b => b.Schedule)
                        .ThenInclude(s => s.PolNavigation)
                    .Include(b => b.Schedule)
                        .ThenInclude(s => s.PodNavigation)
                    .Include(b => b.BookingWareHouses)
                        .ThenInclude(bw => bw.WhareHouse)
                    .Include(b => b.Trackings)

                    .FirstOrDefault(m => m.BillId == id);

                return View(billOfLading);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Lỗi xảy ra khi lấy chi tiết vận đơn");
                return RedirectToAction("Error", "Home");
            }
        }


    }
}

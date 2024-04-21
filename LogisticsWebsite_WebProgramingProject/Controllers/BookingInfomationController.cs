using LogisticsWebsite_WebProgramingProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
namespace LogisticsWebsite_WebProgramingProject.Controllers
{
    [Authorize]
    public class BookingInfomationController : Controller
    {
        private readonly IBillofladingRepository _billofladingRepository;
        private readonly IBookinginfomationRepository _bookinginfomationRepository;
        private readonly IPortRepository _portReponsitory;
        private readonly IScheduleRepository _scheduleReponsitory;
        private readonly LogisticsContext _logisticsContext;
        private readonly IContainerRepository _ContainerReponsitory;
        private readonly UserManager<ApplicationUser> _userManager;
        public BookingInfomationController(LogisticsContext logisticsContext, IBookinginfomationRepository bookinginfomationRepository, IBillofladingRepository billofladingRepository,
            IScheduleRepository scheduleReponsitory, IPortRepository portReponsitory, IContainerRepository containerReponsitory, UserManager<ApplicationUser> userManager)
        {
            _logisticsContext = logisticsContext;
            _billofladingRepository = billofladingRepository;
            _bookinginfomationRepository = bookinginfomationRepository;
            _scheduleReponsitory = scheduleReponsitory;
            _portReponsitory = portReponsitory;
            _userManager = userManager;
            _ContainerReponsitory = containerReponsitory;
        }

        public async Task<IActionResult> Index()
        {
            var schedules = await _logisticsContext.Schedules
              .Include(s => s.PodNavigation)
              .Include(s => s.PolNavigation)
              .Include(s => s.Ship)
              .ToListAsync();
            return RedirectToAction("CreateBillOfLading", "BillOfLading");
        }

        public async Task<IActionResult> Add()
        {
            // Truy xuất danh sách các cảng từ repository
            var ports = await _portReponsitory.GetAllAsync();
            var portItems = ports.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Name.ToString()
            }).ToList();
            var priceOwnerOptions = new List<SelectListItem>
             {
                   new SelectListItem { Text = "Yes", Value = "true" },
                   new SelectListItem { Text = "No", Value = "false" }
             };
           
        
            //Gán danh sách các mục cảng cho ViewBag hoặc ViewModel
            ViewBag.Ports = portItems;
            ViewBag.PriceOwnerOptions = priceOwnerOptions;
            var viewModel = new BookingInfomation();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BookingInfomation bookinginfo)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var today = DateOnly.FromDateTime(DateTime.Today);
                // Tạo đối tượng BookingInfomation từ dữ liệu được gửi từ view
                var bookingInfo = new BookingInfomation
                {

                    // Gán các thuộc tính của BookingInfomation từ viewModel
                    From = bookinginfo.From,
                    To = bookinginfo.To,
                    Commodity = bookinginfo.Commodity,
                    PriceOwner = bookinginfo.PriceOwner,
                    CutOffSi = today.AddDays(14),
                    CutOffCy = today.AddDays(12),
                     UserId = user.Id,
                };
                // Thêm thông tin đặt chỗ vào cơ sở dữ liệu thông qua repository
                await _bookinginfomationRepository.AddAsync(bookingInfo);
                // Chuyển hướng người dùng đến trang chi tiết của thông tin đặt chỗ sau khi thêm thành công
                return RedirectToAction("CreateBillOfLading", "BillOfLading");
            }
            catch (Exception ex)
            {



                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult tracking()
        {
            var tracking = _logisticsContext.BookingInfomations.ToList();
            return View(tracking);
        }
    }
}


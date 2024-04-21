using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{
    public class ScheduleAdminController : Controller
    {
        private readonly IShipAdminRepository _IShipRepository;
        private readonly IScheduleAdminRepository _IScheduleRepository;
        private readonly IPortAdminRepository _IPortRepository;

        public ScheduleAdminController(IShipAdminRepository IShipRepository, IScheduleAdminRepository iScheduleRepository, IPortAdminRepository portRepository)
        {
            _IShipRepository = IShipRepository;
            _IScheduleRepository = iScheduleRepository;
            _IPortRepository = portRepository;
        }
        public async Task<IActionResult> Index()
        {
            var Sche = await _IScheduleRepository.GetAllAsync();
            return View(Sche);
        }
        public async Task<IActionResult> Add()
        {
            var ship = await _IShipRepository.GetAllAsync();
            ViewBag.Ships = new SelectList(ship, "ShipId", "ShipName");
            var port = await _IPortRepository.GetAllAsync();
            ViewBag.Ports = new SelectList(port, "PortId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Schedule sche)
        {
            if (sche == null)
            {
                return View();

            }
            DateOnly day = DateOnly.FromDateTime(DateTime.Now.AddDays(15));
            if (day > sche.DayGo || day > sche.DayCome || sche.DayGo > sche.DayCome)
            {
                var ship = await _IShipRepository.GetAllAsync();
                ViewBag.Ships = new SelectList(ship, "ShipId", "ShipName");
                var port = await _IPortRepository.GetAllAsync();
                ViewBag.Ports = new SelectList(port, "PortId", "Name");

                ViewData["Error"] = $"DayGo and DayCome > {day} and DayGo < DayCome";

                return View(sche);//trả về view cho nhập lại
            }
            await _IScheduleRepository.AddAsync(sche);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            var sche = await _IScheduleRepository.GetByIdAsync(id);
            if (sche == null)
            {
                return NotFound();
            }
            return View(sche);
        }




        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _IScheduleRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var sche = await _IScheduleRepository.GetByIdAsync(id);
            if (sche == null)
            {
                return NotFound();
            }
            var ship = await _IShipRepository.GetAllAsync();
            ViewBag.Ships = new SelectList(ship, "ShipId", "ShipName");
            var port = await _IPortRepository.GetAllAsync();
            ViewBag.Ports = new SelectList(port, "PortId", "Name");
            return View(sche);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Schedule sche)
        {
            if (id != sche.ScheduleId)
            {
                return NotFound();
            }
            var existingSchedule = await _IScheduleRepository.GetByIdAsync(id);
            existingSchedule.ShipId = sche.ShipId;
            existingSchedule.Pol = sche.Pol;
            existingSchedule.Pod = sche.Pod;
            existingSchedule.DayCome = sche.DayCome;
            existingSchedule.DayGo = sche.DayGo;
            existingSchedule.TimeGo = sche.TimeGo;
            existingSchedule.Price = sche.Price;
            await _IScheduleRepository.UpdateAsync(existingSchedule);
            return RedirectToAction(nameof(Index));
        }
    }
}


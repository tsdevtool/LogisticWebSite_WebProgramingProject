using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{
    public class ShipAdminController : Controller
    {
        private readonly IShipAdminRepository _IShipRepository;
        private readonly IScheduleAdminRepository _IScheduleRepository;
        private readonly IScheduleAdminRepository _IscheduleRepository;

        public ShipAdminController(IShipAdminRepository IShipRepository, IScheduleAdminRepository iScheduleRepository, IScheduleAdminRepository scheduleRepository)
        {
            _IShipRepository = IShipRepository;
            _IScheduleRepository = iScheduleRepository;
            _IScheduleRepository = scheduleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ships = await _IShipRepository.GetAllAsync();
            return View(ships);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Ship ships)
        {
            if (ModelState.IsValid)
            {
                await _IShipRepository.AddAsync(ships);
                return RedirectToAction(nameof(Index));
            }
            return View(ships);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var ship = await _IShipRepository.GetByIdAsync(id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }


        // Xử lý xóa sản phẩm

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sche = await _IscheduleRepository.GetByShipIDAsync(id);
            if (sche != null)
            {
                foreach (var schedule in sche)
                {
                    await _IScheduleRepository.DeleteAsync(schedule.ScheduleId);
                }
            }

            await _IShipRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var ship = await _IShipRepository.GetByIdAsync(id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);

        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, Ship ship)
        {
            if (ModelState.IsValid)
            {
                var existingShip = await _IShipRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync

                // Cập nhật các thông tin khác của sản phẩm
                existingShip.ShipName = ship.ShipName;
                existingShip.ShipCode = ship.ShipCode;
                existingShip.Status = ship.Status;
                await _IShipRepository.UpdateAsync(existingShip);
                return RedirectToAction(nameof(Index));
            }

            return View(ship);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}

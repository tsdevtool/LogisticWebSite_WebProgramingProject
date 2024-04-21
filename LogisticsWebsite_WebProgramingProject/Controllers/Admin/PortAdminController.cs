using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{
    public class PortAdminController : Controller
    {
        private readonly IPortAdminRepository _portRepository;
        private readonly IScheduleAdminRepository _scheduleRepository;
        public PortAdminController(IPortAdminRepository portRepository, IScheduleAdminRepository scheduleRepository)
        {
            _portRepository = portRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var port = await _portRepository.GetAllAsync();
            return View(port);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Port port)
        {
            if (ModelState.IsValid)
            {
                await _portRepository.AddAsync(port);
                return RedirectToAction(nameof(Index));
            }
            return View(port);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var port = await _portRepository.GetByIdAsync(id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }


        // Xử lý xóa sản phẩm

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sche = await _scheduleRepository.GetByPortIDAsync(id);
            if (sche != null)
            {
                foreach (var schedule in sche)
                {
                    await _scheduleRepository.DeleteAsync(schedule.ScheduleId);
                }

            }
            await _portRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var port = await _portRepository.GetByIdAsync(id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);

        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, Port port)
        {
            if (ModelState.IsValid)
            {
                var existingPort = await _portRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync

                // Cập nhật các thông tin khác của sản phẩm
                existingPort.Address = port.Address;
                existingPort.Name = port.Name;

                await _portRepository.UpdateAsync(existingPort);
                return RedirectToAction(nameof(Index));
            }

            return View(port);
        }
    }
}

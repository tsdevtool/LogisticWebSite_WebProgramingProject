using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{
    public class WareHouseAdminController : Controller
    {
        private readonly IWareHouseAdminRepository _IwarehouseRepository;

        public WareHouseAdminController(IWareHouseAdminRepository wareHouseRepository)
        {
            _IwarehouseRepository = wareHouseRepository;

        }
        public async Task<IActionResult> Index()
        {
            var wh = await _IwarehouseRepository.GetAllAsync();
            return View(wh);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(WareHouse wareHouse)
        {
            if (ModelState.IsValid)
            {
                await _IwarehouseRepository.AddAsync(wareHouse);
                return RedirectToAction(nameof(Index));
            }
            return View(wareHouse);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var wh = await _IwarehouseRepository.GetByIdAsync(id);
            if (wh == null)
            {
                return NotFound();
            }

            return View(wh);
        }


        // Xử lý xóa sản phẩm

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _IwarehouseRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var wareHouse = await _IwarehouseRepository.GetByIdAsync(id);
            if (wareHouse == null)
            {
                return NotFound();
            }

            return View(wareHouse);

        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, WareHouse wareHouse)
        {
            if (ModelState.IsValid)
            {
                var existingWareHouse = await _IwarehouseRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync

                // Cập nhật các thông tin khác của sản phẩm
                existingWareHouse.Price = wareHouse.Price;
                existingWareHouse.Type = wareHouse.Type;

                await _IwarehouseRepository.UpdateAsync(existingWareHouse);
                return RedirectToAction(nameof(Index));
            }

            return View(wareHouse);
        }
    }
}

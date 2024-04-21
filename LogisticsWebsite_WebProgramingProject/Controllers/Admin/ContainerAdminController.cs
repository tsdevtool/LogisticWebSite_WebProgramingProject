using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{
    public class ContainerAdminController : Controller
    {
        private readonly IContainerAdminRepository _containerRepository;
        public ContainerAdminController(IContainerAdminRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }
        public async Task<IActionResult> Index()
        {
            var container = await _containerRepository.GetAllAsync();
            return View(container);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var container = await _containerRepository.GetByIdAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _containerRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var port = await _containerRepository.GetByIdAsync(id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);

        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, Container container)
        {
            if (ModelState.IsValid)
            {
                var existingContainer = await _containerRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync

                // Cập nhật các thông tin khác của sản phẩm
                existingContainer.CargoWeight = container.CargoWeight;
                existingContainer.ContainerSize = container.ContainerSize;
                existingContainer.NumberOfContainer = container.NumberOfContainer;
                existingContainer.Type = container.Type;
                existingContainer.PlaceToPickUp = container.PlaceToPickUp;


                await _containerRepository.UpdateAsync(existingContainer);
                return RedirectToAction(nameof(Index));
            }

            return View(container);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Container container)
        {
            if (ModelState.IsValid)
            {
                await _containerRepository.AddAsync(container);
                return RedirectToAction(nameof(Index));
            }
            return View(container);
        }
    }
}

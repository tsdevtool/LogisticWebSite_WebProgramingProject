using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{
    public class CostsIncurredAdminController : Controller
    {
        private readonly ICostsIncurredAdminRepository _IcostsIncurredRepository;
        private readonly IBillOfLadingAdminRepository _IbillOfLading;
        public CostsIncurredAdminController(ICostsIncurredAdminRepository costsIncurredRepository, IBillOfLadingAdminRepository billOfLading)
        {
            _IcostsIncurredRepository = costsIncurredRepository;
            _IbillOfLading = billOfLading;
        }
        public async Task<IActionResult> Index()
        {
            var cost = await _IcostsIncurredRepository.GetAllAsync();
            return View(cost);
        }
        /*public async Task<IActionResult> Delete(int id)  SẼ KHÔNG CHO XÓA NHỮNG CHI PHÍ PHÁT SINH
		{
			var container = await _IcostsIncurredRepository.GetByIdAsync(id);
			if (container == null)
			{
				return NotFound();
			}

			return View(container);
		}*/
        /*public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _IcostsIncurredRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}*/
        public async Task<IActionResult> Update(int id)
        {
            var port = await _IcostsIncurredRepository.GetByIdAsync(id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);

        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, CostsIncurred costsIncurred)
        {

            var existingContainer = await _IcostsIncurredRepository.GetByIdAsync(id);

            existingContainer.Name = costsIncurred.Name;
            existingContainer.Price = costsIncurred.Price;

            await _IcostsIncurredRepository.UpdateAsync(existingContainer);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> SelectAdd()
        {
            var Listbill = await _IbillOfLading.GetAllAsync(); // select tất cả billoflading

            return View(Listbill);
        }
        public async Task<IActionResult> Add(int id) //truyền id billoflading được chọn vào hàm
        {
            CostsIncurred cost = new CostsIncurred();
            cost.BillId = id;
            return View(cost);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CostsIncurred costsIncurred)
        {

            await _IcostsIncurredRepository.AddAsync(costsIncurred);
            return RedirectToAction(nameof(Index));


        }
    }
}

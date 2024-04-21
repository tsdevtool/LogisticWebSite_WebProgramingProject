using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{
    public class InvoiceAdminController : Controller
    {
        private readonly ICostsIncurredAdminRepository _IcostsIncurredRepository;
        private readonly IInvoiceAdminRepository _IinvoiceRepository;
        private readonly IBillOfLadingAdminRepository _IbillOfLading;
        private readonly IScheduleAdminRepository _ScheduleRepository;
        private readonly IWareHouseAdminRepository _WareHouseAdminRepository;
        private readonly IBookingWareHouseAdminRepository _BookingWareHouseAdminRepository;
        public InvoiceAdminController(IInvoiceAdminRepository iinvoiceRepository, IBillOfLadingAdminRepository ibillOfLading, ICostsIncurredAdminRepository icostsIncurredRepository, IScheduleAdminRepository scheduleRepository, IWareHouseAdminRepository wareHouseAdminRepository, IBookingWareHouseAdminRepository bookingWareHouseAdminRepository)
        {
            _IinvoiceRepository = iinvoiceRepository;
            _IbillOfLading = ibillOfLading;
            _IcostsIncurredRepository = icostsIncurredRepository;
            _ScheduleRepository = scheduleRepository;
            _WareHouseAdminRepository = wareHouseAdminRepository;
            _BookingWareHouseAdminRepository = bookingWareHouseAdminRepository;
        }

        public async Task<IActionResult> Index()
        {
            var invoices = await _IinvoiceRepository.GetAllAsync();
            return View(invoices);
        }
        public async Task<IActionResult> SelectAdd()
        {
            var Listbill = await _IbillOfLading.GetAllAsync(); // select tất cả billoflading
            return View(Listbill);
        }
        public async Task<IActionResult> Add(int id2) //truyền id billoflading được chọn vào hàm
        {
            var cost = await _IcostsIncurredRepository.GetByBillofLadingIdAsync(id2);//lấy thông tin chi phí phát sinh theo billID
            var bill = await _IbillOfLading.GetByBillOfLadingIDAsync(id2);//lấy thông tin billoflading để truy xuất ra lịch trình
            var schedule = await _ScheduleRepository.GetByIdAsync(bill.ScheduleId);
            Invoice invoice = new Invoice();
            var bkwh = await _BookingWareHouseAdminRepository.GetByIdBillAsync(id2);
            if (bkwh != null)
            {
                var wh = await _WareHouseAdminRepository.GetByIdAsync(bkwh.WhareHouseId);
                var money = wh.Price;
                if (cost != null)
                {
                    invoice.BillId = bill.BillId;
                    invoice.CostsIncurredId = cost.CostsIncurredId;
                    invoice.Status = false;
                    invoice.Total = cost.Price + schedule.Price + money;
                }
                else
                {
                    invoice.BillId = bill.BillId;
                    invoice.Status = false;
                    invoice.Total = schedule.Price + money;
                }


            }
            else
            {
                if (cost != null)
                {
                    invoice.BillId = bill.BillId;
                    invoice.CostsIncurredId = cost.CostsIncurredId;
                    invoice.Status = false;
                    invoice.Total = cost.Price + schedule.Price;
                }
                else
                {
                    invoice.BillId = bill.BillId;
                    invoice.Status = false;
                    invoice.Total = schedule.Price;
                }
            }

            return View(invoice);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Invoice invoice)
        {
            if (invoice.Surcharge == 0)
            {
                /*invoice.Id = 0;*/
                await _IinvoiceRepository.AddAsync(invoice);
            }
            else
            {
                /*invoice.Id = 0;// lúc add lại tự sinh cho 1 giá trị id cụ thể nhưng id trong sql là tự sinh nên cần phải để null*/
                invoice.Total = invoice.Total + invoice.Surcharge;
                await _IinvoiceRepository.AddAsync(invoice);
            }
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            var invoice = await _IinvoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);

        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, Invoice invoice)
        {

            var existingInvoice = await _IinvoiceRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync

            existingInvoice.Status = invoice.Status;
            existingInvoice.Total = existingInvoice.Total - existingInvoice.Surcharge + invoice.Surcharge;
            existingInvoice.Surcharge = invoice.Surcharge;

            await _IinvoiceRepository.UpdateAsync(existingInvoice);
            return RedirectToAction(nameof(Index));

        }
    }
}

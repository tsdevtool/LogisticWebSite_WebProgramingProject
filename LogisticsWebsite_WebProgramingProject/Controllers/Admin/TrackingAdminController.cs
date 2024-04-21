using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsWebsite_WebProgramingProject.Controllers.Admin
{
	public class TrackingAdminController : Controller
	{
		public readonly ITrackingAdminRepository _ItrackingAdminRepository;
		public readonly IScheduleAdminRepository _IscheduleAdminRepository;
		public readonly IBillOfLadingAdminRepository _IbillOfLadingAdminRepository;

		public TrackingAdminController (ITrackingAdminRepository itrackingAdminRepository, IScheduleAdminRepository ischeduleAdminRepository, IBillOfLadingAdminRepository ibillOfLadingAdminRepository)
		{
			_ItrackingAdminRepository = itrackingAdminRepository;
			_IscheduleAdminRepository = ischeduleAdminRepository;
			_IbillOfLadingAdminRepository = ibillOfLadingAdminRepository;
		}
		public async Task<IActionResult> Index()
		{
			var listTracking = await _ItrackingAdminRepository.GetAllAsync();
			return View(listTracking);
		}
		public async Task<IActionResult> Update(int id) //1 tracking
		{
			var tracking = await _ItrackingAdminRepository.GetByIdAsync(id);
			if (tracking == null)
			{
				return NotFound();
			}

			return View(tracking);

		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, Tracking tracking)
		{
				var existingTracking = await _ItrackingAdminRepository.GetByIdAsync(id); 

				existingTracking.Status = tracking.Status;
				
				await _ItrackingAdminRepository.UpdateAsync(existingTracking);
				return RedirectToAction(nameof(Index));
			
		}
		public async Task<IActionResult> SelectSchedule() //1 list theo schedule
		{
			var schedule = await _IscheduleAdminRepository.GetAllAsync();
			if (schedule == null)
			{
				return NotFound();
			}

			return View(schedule);

		}
		public async Task<IActionResult> UpdateList(int id) //1 list theo schedule
		{
			var bill = await _IbillOfLadingAdminRepository.GetByScheduleIDAsync(id);
			if(bill == null)
			{
				return NotFound();
			}	
			List<Tracking> listTracking = new List<Tracking>();
			foreach(var item in bill)
			{
				var tracking = await _ItrackingAdminRepository.GetByBillIdAsync(item.BillId);
				listTracking.Add(tracking);
			}
			return View(listTracking);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateList(String status, List<Tracking> Listtracking)
		{
			foreach(var item in Listtracking)
			{
				var tracking = await _ItrackingAdminRepository.GetByIdAsync(item.TrackingId);
				tracking.Status = status;
				await _ItrackingAdminRepository.UpdateAsync(tracking);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}

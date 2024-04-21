using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticsWebsite_WebProgramingProject.Controllers
{
    public class AdminController : Controller
    {
		private readonly IBillOfLadingAdminRepository _IBillOfLading;
        private readonly LogisticsContext _context;

        public AdminController(IBillOfLadingAdminRepository iBillOfLading)
		{
			_IBillOfLading = iBillOfLading;
		}
		public async Task<IActionResult> Index()
		{
			var booking = await _IBillOfLading.GetAllAsync();
			return View(booking);
		}
        private readonly UserManager<IdentityUser> _userManager;

        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.ToListAsync();
            // Process or return the user list as needed
            return View(users);
        }
    }

    
}

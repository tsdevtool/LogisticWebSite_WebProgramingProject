using LogisticsWebsite_WebProgramingProject.Repositories;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticsWebsite_WebProgramingProject.Controllers
{
    public class ScheduleController : Controller
    {
       
        private readonly IScheduleRepository _IScheduleRepository;
        private readonly IPortRepository _IPortRepository;

        public ScheduleController( IScheduleRepository iScheduleRepository, IPortRepository portRepository)
        {
            _IScheduleRepository = iScheduleRepository;
            _IPortRepository = portRepository;
        }
        public async Task<IActionResult> Index()
        {
            var Sche = await _IScheduleRepository.GetAsync();
            return View(Sche);
        }
    }
}

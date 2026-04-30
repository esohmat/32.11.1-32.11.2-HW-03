using Microsoft.AspNetCore.Mvc;
using MvcStartApp1.Data.Interfaces;

namespace MvcStartApp1.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestLogRepository _logRepo;

        public LogsController(IRequestLogRepository logRepo)
        {
            _logRepo = logRepo;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _logRepo.GetAllRequestsAsync();
            return View(logs);
        }
    }
}
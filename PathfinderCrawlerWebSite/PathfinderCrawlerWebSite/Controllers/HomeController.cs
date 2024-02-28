using Microsoft.AspNetCore.Mvc;
using PathfinderCrawlerWebSite.IService;

namespace PathfinderCrawlerWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICrawlerService _crawlerService;

        public HomeController(ILogger<HomeController> logger,
            ICrawlerService crawlerService)
        {
            _logger = logger;
            _crawlerService = crawlerService;
        }

        public IActionResult Index()
        {
             _crawlerService.HttpGetMyWrok();
            return View();
        }
    }
}
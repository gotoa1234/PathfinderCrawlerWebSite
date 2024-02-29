using Microsoft.AspNetCore.Mvc;
using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.IService.Magic;

namespace PathfinderCrawlerWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArcaneSpellsService _arcaneSpellsService;

        public HomeController(ILogger<HomeController> logger,
            IArcaneSpellsService arcaneSpellsService)
        {
            _logger = logger;
            _arcaneSpellsService = arcaneSpellsService;
        }

        public IActionResult Index()
        {
            _arcaneSpellsService.Trick();
            return View();
        }
    }
}
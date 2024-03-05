using Microsoft.AspNetCore.Mvc;
using PathfinderCrawlerWebSite.Common;
using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.IService.Magic;
using PathfinderCrawlerWebSite.Models.Magic;

namespace PathfinderCrawlerWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;        
        private readonly IGenerateFileService _generateFileService;       

        public HomeController(ILogger<HomeController> logger,            
            IGenerateFileService generateAvroFileService)
        {
            _logger = logger;            
            _generateFileService = generateAvroFileService;
        }

        public IActionResult Index()
        {
            var collections = new List<SpellModel>();
            try
            {
                GlobalVariable._SequenceId = 1;
                _generateFileService.GeneratorFile();                
            }
            catch (Exception ex)
            { 
            
            }
            
            return View();
        }
    }
}
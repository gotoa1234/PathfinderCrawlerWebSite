using Microsoft.AspNetCore.Mvc;
using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.IService.Magic;
using PathfinderCrawlerWebSite.Models.Magic;

namespace PathfinderCrawlerWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArcaneSpellsService _arcaneSpellsService;
        private readonly IGenerateAvroFileService _generateAvroFileService;

        public HomeController(ILogger<HomeController> logger,
            IArcaneSpellsService arcaneSpellsService,
            IGenerateAvroFileService generateAvroFileService)
        {
            _logger = logger;
            _arcaneSpellsService = arcaneSpellsService;
            _generateAvroFileService = generateAvroFileService;
        }

        public IActionResult Index()
        {
            var collections = new List<SpellModel>();
            try
            {
                var temp = _arcaneSpellsService.Trick();
                collections.AddRange(temp);
                _generateAvroFileService.GeneratorSpellModelAvroFile(collections);

                //temp = _arcaneSpellsService.LevelFirstSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelSecondSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelThirdSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelFourthSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelFifthSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelSixthSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelSeventhSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelEighthSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelNighthSpell();
                //collections.AddRange(temp);
                //temp = _arcaneSpellsService.LevelTenthSpell();
                //collections.AddRange(temp);
            }
            catch (Exception ex)
            { 
            
            }
            
            return View();
        }
    }
}
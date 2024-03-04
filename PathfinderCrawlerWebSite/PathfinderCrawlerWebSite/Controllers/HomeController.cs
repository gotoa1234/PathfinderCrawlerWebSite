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
                GlobalVariable._SequenceId = 1;
                var temp = _arcaneSpellsService.Trick();
                collections.AddRange(temp);
                _generateAvroFileService.GeneratorSpellModelAvroFile(collections);
                //collections.AddRange(_arcaneSpellsService.LevelFirstSpell());
                //collections.AddRange(_arcaneSpellsService.LevelSecondSpell());                
                //collections.AddRange(_arcaneSpellsService.LevelThirdSpell());                
                //collections.AddRange(_arcaneSpellsService.LevelFourthSpell());                
                //collections.AddRange(_arcaneSpellsService.LevelFifthSpell());                
                //collections.AddRange(_arcaneSpellsService.LevelSixthSpell());                
                //collections.AddRange(_arcaneSpellsService.LevelSeventhSpell());                
                //collections.AddRange(_arcaneSpellsService.LevelEighthSpell());                
                //collections.AddRange(_arcaneSpellsService.LevelNighthSpell());                
                //collections.AddRange(_arcaneSpellsService.LevelTenthSpell());
            }
            catch (Exception ex)
            { 
            
            }
            
            return View();
        }
    }
}
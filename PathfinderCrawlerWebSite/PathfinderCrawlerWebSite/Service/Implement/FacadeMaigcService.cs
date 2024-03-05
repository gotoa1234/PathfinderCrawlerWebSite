using Newtonsoft.Json;
using PathfinderCrawlerWebSite.Common;
using PathfinderCrawlerWebSite.IService.Magic;
using PathfinderCrawlerWebSite.Models.Magic;
using PathfinderCrawlerWebSite.Service.IService;

namespace PathfinderCrawlerWebSite.Service.Implement
{
    public class FacadeMaigcService : IFacadeMaigcService
    {
        private IArcaneSpellsService _arcaneSpellsService;
        private IDivineSpellsService _divineSpellsService;
        private IOccultSpellsService _occultSpellsService;
        private IPrimalSpellsService _primalSpellsService;

        public FacadeMaigcService(IArcaneSpellsService arcaneSpellsService,
            IDivineSpellsService divineSpellsService,
            IOccultSpellsService occultSpellsService,
            IPrimalSpellsService primalSpellsService)
        {
            _arcaneSpellsService = arcaneSpellsService;
            _divineSpellsService = divineSpellsService;
            _occultSpellsService = occultSpellsService;
            _primalSpellsService = primalSpellsService;
        }

        public string IntergrationWorking()
        {
            var collections = new List<SpellModel>();
            int milliSecond = 5 * 1000;//休息時間，避免太頻繁抓資料被視為異常
            try
            {
                GlobalVariable._SequenceId = 1;
                collections.AddRange(ArcaneSpellCollections());
                Thread.Sleep(milliSecond);
                collections.AddRange(DivineSpellCollections());
                Thread.Sleep(milliSecond);
                collections.AddRange(OccultSpellCollections());
                Thread.Sleep(milliSecond);
                collections.AddRange(PrimalSpellCollections());
                Thread.Sleep(milliSecond);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }

            var resultJson = JsonConvert.SerializeObject(collections);
            return resultJson;
        }

        private List<SpellModel> ArcaneSpellCollections()
        {
            var collections = new List<SpellModel>();
            collections.AddRange(_arcaneSpellsService.Trick());
            collections.AddRange(_arcaneSpellsService.LevelFirstSpell());
            collections.AddRange(_arcaneSpellsService.LevelSecondSpell());
            collections.AddRange(_arcaneSpellsService.LevelThirdSpell());
            collections.AddRange(_arcaneSpellsService.LevelFourthSpell());
            collections.AddRange(_arcaneSpellsService.LevelFifthSpell());
            collections.AddRange(_arcaneSpellsService.LevelSixthSpell());
            collections.AddRange(_arcaneSpellsService.LevelSeventhSpell());
            collections.AddRange(_arcaneSpellsService.LevelEighthSpell());
            collections.AddRange(_arcaneSpellsService.LevelNighthSpell());
            collections.AddRange(_arcaneSpellsService.LevelTenthSpell());
            return collections;
        }

        private List<SpellModel> DivineSpellCollections()
        {
            var collections = new List<SpellModel>();
            collections.AddRange(_divineSpellsService.Trick());
            collections.AddRange(_divineSpellsService.LevelFirstSpell());
            collections.AddRange(_divineSpellsService.LevelSecondSpell());
            collections.AddRange(_divineSpellsService.LevelThirdSpell());
            collections.AddRange(_divineSpellsService.LevelFourthSpell());
            collections.AddRange(_divineSpellsService.LevelFifthSpell());
            collections.AddRange(_divineSpellsService.LevelSixthSpell());
            collections.AddRange(_divineSpellsService.LevelSeventhSpell());
            collections.AddRange(_divineSpellsService.LevelEighthSpell());
            collections.AddRange(_divineSpellsService.LevelNighthSpell());
            collections.AddRange(_divineSpellsService.LevelTenthSpell());
            return collections;
        }

        private List<SpellModel> OccultSpellCollections()
        {
            var collections = new List<SpellModel>();
            collections.AddRange(_occultSpellsService.Trick());
            collections.AddRange(_occultSpellsService.LevelFirstSpell());
            collections.AddRange(_occultSpellsService.LevelSecondSpell());
            collections.AddRange(_occultSpellsService.LevelThirdSpell());
            collections.AddRange(_occultSpellsService.LevelFourthSpell());
            collections.AddRange(_occultSpellsService.LevelFifthSpell());
            collections.AddRange(_occultSpellsService.LevelSixthSpell());
            collections.AddRange(_occultSpellsService.LevelSeventhSpell());
            collections.AddRange(_occultSpellsService.LevelEighthSpell());
            collections.AddRange(_occultSpellsService.LevelNighthSpell());
            collections.AddRange(_occultSpellsService.LevelTenthSpell());
            return collections;
        }

        private List<SpellModel> PrimalSpellCollections()
        {
            var collections = new List<SpellModel>();
            collections.AddRange(_primalSpellsService.Trick());
            collections.AddRange(_primalSpellsService.LevelFirstSpell());
            collections.AddRange(_primalSpellsService.LevelSecondSpell());
            collections.AddRange(_primalSpellsService.LevelThirdSpell());
            collections.AddRange(_primalSpellsService.LevelFourthSpell());
            collections.AddRange(_primalSpellsService.LevelFifthSpell());
            collections.AddRange(_primalSpellsService.LevelSixthSpell());
            collections.AddRange(_primalSpellsService.LevelSeventhSpell());
            collections.AddRange(_primalSpellsService.LevelEighthSpell());
            collections.AddRange(_primalSpellsService.LevelNighthSpell());
            collections.AddRange(_primalSpellsService.LevelTenthSpell());
            return collections;
        }

    }
}

using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.IService.Magic;

namespace PathfinderCrawlerWebSite.Service.Implement.Magic
{
    public class ArcaneSpellsService : IArcaneSpellsService
    {
        private ICrawlerService _crawlerService;

        public ArcaneSpellsService(ICrawlerService crawlerService)
        {
            _crawlerService = crawlerService;
        }

        public void LevelEighthSpell()
        {
            var pathUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_185.html";

            

            throw new NotImplementedException();
        }

        public void LevelFifthSpell()
        {
            throw new NotImplementedException();
        }

        public void LevelFirstSpell()
        {
            throw new NotImplementedException();
        }

        public void LevelFourthSpell()
        {
            throw new NotImplementedException();
        }

        public void LevelNighthSpell()
        {
            throw new NotImplementedException();
        }

        public void LevelSecondSpell()
        {
            throw new NotImplementedException();
        }

        public void LevelSeventhSpell()
        {
            throw new NotImplementedException();
        }

        public void LevelSixthSpell()
        {
            throw new NotImplementedException();
        }

        public void LevelTenthSpell()
        {
            throw new NotImplementedException();
        }

        public void LevelThirdSpell()
        {
            throw new NotImplementedException();
        }

        public void Trick()
        {
            throw new NotImplementedException();
        }
    }
}

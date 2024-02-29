using HtmlAgilityPack;
using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.IService.Magic;
using PathfinderCrawlerWebSite.Models.Magic;

namespace PathfinderCrawlerWebSite.Service.Implement.Magic
{
    public class ArcaneSpellsService : IArcaneSpellsService
    {
        private ICrawlerService _crawlerService;

        public ArcaneSpellsService(ICrawlerService crawlerService)
        {
            _crawlerService = crawlerService;
        }

        /// <summary>
        /// 戲法
        /// </summary>        
        public void Trick()
        {
            var pathUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_185.html";
            var doc = _crawlerService.HttpGetMyWrok(pathUrl);
            // Create XPathDocument
            try
            {
                // XPath 
                HtmlNodeCollection allSpells = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div");
                var results = new List<SpellModel>();
                foreach (var spell in allSpells) 
                {
                    try
                    {
                        var myData = new SpellModel(spell);
                        results.Add(myData);
                    }
                    catch { 
                        //捨棄無法轉換的資料
                    }
                }                
            }
            catch (Exception ex)
            {

            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 一環法術
        /// </summary>        
        public void LevelEighthSpell()
        {
            var pathUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_186.html";
            _crawlerService.HttpGetMyWrok(pathUrl);
            
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


    }
}

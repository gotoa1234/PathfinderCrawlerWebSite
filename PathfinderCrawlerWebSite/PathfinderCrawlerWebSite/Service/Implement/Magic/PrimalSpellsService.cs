using PathfinderCrawlerWebSite.Common;
using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.IService.Magic;
using PathfinderCrawlerWebSite.Models.Magic;
using PathfinderCrawlerWebSite.Service.IService.Magic;

namespace PathfinderCrawlerWebSite.Service.Implement.Magic
{
    public class PrimalSpellsService : IPrimalSpellsService
    {
        private ICrawlerService _crawlerService;
        private ISpellsBaseService _spellsBaseService;        

        public PrimalSpellsService(ICrawlerService crawlerService,
             ISpellsBaseService spellsBaseService)
        {
            _crawlerService = crawlerService;
            _spellsBaseService = spellsBaseService;
        }

        /// <summary>
        /// 戲法
        /// </summary>        
        public List<SpellModel> Trick()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.Trick);
            var levelName = SpellLevelEnum.Trick;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_218.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 一環法術
        /// </summary>        
        public List<SpellModel> LevelFirstSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelFirstSpell);
            var levelName = SpellLevelEnum.LevelFirstSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_219.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 二環法術
        /// </summary>        
        public List<SpellModel> LevelSecondSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelSecondSpell);
            var levelName = SpellLevelEnum.LevelSecondSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_220.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 三環法術
        /// </summary>        
        public List<SpellModel> LevelThirdSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelThirdSpell);
            var levelName = SpellLevelEnum.LevelThirdSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_221.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 四環法術
        /// </summary>        
        public List<SpellModel> LevelFourthSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelFourthSpell);
            var levelName = SpellLevelEnum.LevelFourthSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_222.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 五環法術
        /// </summary>        
        public List<SpellModel> LevelFifthSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelFifthSpell);
            var levelName = SpellLevelEnum.LevelFifthSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_223.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 六環法術
        /// </summary>        
        public List<SpellModel> LevelSixthSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelSixthSpell);
            var levelName = SpellLevelEnum.LevelSixthSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_224.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 七環法術
        /// </summary>        
        public List<SpellModel> LevelSeventhSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelSeventhSpell);
            var levelName = SpellLevelEnum.LevelSeventhSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_225.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 八環法術
        /// </summary>        
        public List<SpellModel> LevelEighthSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelEighthSpell);
            var levelName = SpellLevelEnum.LevelEighthSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_226.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 九環法術
        /// </summary>        
        public List<SpellModel> LevelNighthSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelNighthSpell);
            var levelName = SpellLevelEnum.LevelNighthSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_227.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }

        /// <summary>
        /// 十環法術
        /// </summary>        
        public List<SpellModel> LevelTenthSpell()
        {
            //Base Data
            var className = nameof(SpellClassEnum.Primal);
            var classChineseName = SpellClassEnum.Primal;
            var level = nameof(SpellLevelEnum.LevelTenthSpell);
            var levelName = SpellLevelEnum.LevelTenthSpell;            
            var sourceDataUrl = $@"https://pf2e.hktrpg.com/topics/%E5%9F%BA%E6%9C%AC/page_228.html";
            var doc = _crawlerService.HttpGetMyWrok(sourceDataUrl);
            //Get Pharse Result
            var results = _spellsBaseService.GetConvertNodeCollections("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div",
                doc, className, classChineseName, level, levelName, sourceDataUrl);
            return results;
        }
    }
}

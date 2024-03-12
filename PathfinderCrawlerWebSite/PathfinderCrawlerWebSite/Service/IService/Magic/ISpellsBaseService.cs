using HtmlAgilityPack;
using PathfinderCrawlerWebSite.Models.Magic;

namespace PathfinderCrawlerWebSite.Service.IService.Magic
{
    public interface ISpellsBaseService
    {
        List<SpellModel> GetConvertNodeCollections(string xpath, HtmlDocument doc,
            string className, string classChineseName, string level, string levelName, string sourceDataUrl);
    }
}

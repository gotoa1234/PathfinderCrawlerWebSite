using HtmlAgilityPack;
using PathfinderCrawlerWebSite.Models.Magic;
using PathfinderCrawlerWebSite.Service.IService.Magic;

namespace PathfinderCrawlerWebSite.Service.Implement.Magic
{
    public class SpellsBaseService: ISpellsBaseService
    {
        /// <summary>
        /// 轉換成共用的資料
        /// </summary>                
        public List<SpellModel> GetConvertNodeCollections(string xpath, HtmlDocument doc,
            string className, string classChineseName, string level, string levelName, string sourceDataUrl)
        {
            var results = new List<SpellModel>();
            try
            {
                // XPath 
                HtmlNodeCollection allSpells = doc.DocumentNode.SelectNodes(xpath);
                foreach (var spell in allSpells)
                {
                    try
                    {
                        var myData = new SpellModel(spell, className, classChineseName, level, levelName, sourceDataUrl);
                        if (!string.IsNullOrEmpty(myData.Name))
                        {
                            results.Add(myData);
                        }
                    }
                    catch
                    {//捨棄無法轉換的資料
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return results;
        }     
    }
}

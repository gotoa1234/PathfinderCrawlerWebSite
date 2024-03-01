using HtmlAgilityPack;
using System.ComponentModel;

namespace PathfinderCrawlerWebSite.Models.MagicModel
{
    public class SpellModel
    {        
        [Description("//div[1]/span[1]")]
        public string Name { get; set; } = string.Empty;

        [Description("//div[1]/span[2]")]
        public int Level { get; set; } = 1;

        [Description("//div[2]/span")]
        public string[] Feature { get; set; } = new string[] { };

        public SpellModel(HtmlNodeCollection xmlNode)
        {
            //每個資料都應該有自己的處理方式
            
       
        }
    }
}

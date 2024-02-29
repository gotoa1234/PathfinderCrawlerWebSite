using HtmlAgilityPack;
using PathfinderCrawlerWebSite.IService;

namespace PathfinderCrawlerWebSite.Service.Implement
{
    public class CrawlerService : ICrawlerService
    {

        public HtmlDocument HttpGetMyWrok(string targetUrl) 
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(targetUrl);                
                return doc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

    }
}

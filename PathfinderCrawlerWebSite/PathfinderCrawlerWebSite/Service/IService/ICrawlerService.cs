using HtmlAgilityPack;

namespace PathfinderCrawlerWebSite.IService
{
    public interface ICrawlerService
    {
        HtmlDocument HttpGetMyWrok(string targetUrl);
    }
}

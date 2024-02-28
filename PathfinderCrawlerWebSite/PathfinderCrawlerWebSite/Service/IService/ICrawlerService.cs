namespace PathfinderCrawlerWebSite.IService
{
    public interface ICrawlerService
    {
        public Task<string> HttpGetMyWrok(string targetUrl);
    }
}

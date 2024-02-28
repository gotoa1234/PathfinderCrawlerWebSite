using PathfinderCrawlerWebSite.IService;

namespace PathfinderCrawlerWebSite.Service.Implement
{
    public class CrawlerService : ICrawlerService
    {

        public async Task<string> HttpGetMyWrok(string targetUrl) 
        {
            //     項目 /html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1] 
            //          /html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2] ... 到 div[x] 


            // 項目名稱 /html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/span[1]
            //      TAG /html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[2]/span[1] ~ span[X]
            //     未知 
            //     說明 /html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[3]/#text[1] 
            // 建立服務提供者
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider();

            // 從服務提供者中取得 HttpClientFactory
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

            // 使用 HttpClientFactory 建立 HttpClient
            var httpClient = httpClientFactory.CreateClient();

            // 發出 GET 請求
            var response = await httpClient.GetAsync(targetUrl);

            // 檢查請求是否成功            
            if (response.IsSuccessStatusCode)
            {
                // 讀取回應的內容
                return await response.Content.ReadAsStringAsync();                
            }
            return "";
        }

    }
}

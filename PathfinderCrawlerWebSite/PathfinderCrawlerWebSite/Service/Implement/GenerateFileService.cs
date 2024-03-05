using Newtonsoft.Json;
using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.Models;
using PathfinderCrawlerWebSite.Models.Magic;
using PathfinderCrawlerWebSite.Service.IService;

namespace PathfinderCrawlerWebSite.Service.Implement
{
    public class GenerateFileService : IGenerateFileService
    {
        private readonly string frontWebSaveFilePath = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).FullName}\PF2EWebSiteFrontend\WebSite\assets\extend\Jsonfile\";
        private readonly string backWebSaveFilePath = $@".\wwwroot\extend\Jsonfile\";
        private readonly IFacadeMaigcService _facadeMaigcService;

        public GenerateFileService(IFacadeMaigcService facadeMaigcService)
        {
            _facadeMaigcService = facadeMaigcService;
        }

        /// <summary>
        /// 產生輸出檔案
        /// </summary>
        public void GeneratorFile()
        {
            var getSpellModelJson = _facadeMaigcService.IntergrationWorking();
            GeneratorSpellModelFile(getSpellModelJson);

            // 最後一定要生成版本號
            GeneratorIndexedDBVersionFile();
        }

        /// <summary>
        /// 產生法術資料檔案(奧術、神術、異能、原能)
        /// </summary>
        private void GeneratorSpellModelFile(string jsonString)
        {            
            var frontWebFileNamePath = $@"{frontWebSaveFilePath}{nameof(SpellModel)}.json";
            var backWebFileNamePath = $@"{backWebSaveFilePath}{nameof(SpellModel)}.json";           ;
            SaveFile(frontWebFileNamePath, backWebFileNamePath, jsonString);
        }

        /// <summary>
        /// 產生版本號檔案 
        /// </summary>
        /// <remarks>
        /// IndexedDB 版本號型別：unsigned long
        /// </remarks>
        /// <returns></returns>
        private void GeneratorIndexedDBVersionFile()
        {
            var newVersion = new VersionModel { };
            var frontWebFileNamePath = $@"{frontWebSaveFilePath}{nameof(newVersion.Version)}.json";
            var backWebFileNamePath = $@"{backWebSaveFilePath}{nameof(newVersion.Version)}.json";

            // 檢查舊有的版本號
            if (File.Exists(backWebFileNamePath))
            {                
                string jsonContent = File.ReadAllText(backWebFileNamePath);
                try
                {
                    newVersion = JsonConvert.DeserializeObject<VersionModel>(jsonContent);
                    newVersion.Version += 1;//遞增
                }
                catch
                {
                    newVersion = new VersionModel() { Version = 2 };
                }
            }

            // 序列化結果
            var jsonString = JsonConvert.SerializeObject(newVersion);

            SaveFile(frontWebFileNamePath, backWebFileNamePath, jsonString);
        }

        /// <summary>
        /// 儲存檔案
        /// </summary>       
        private void SaveFile(string frontWebFileNamePath, string backWebFileNamePath, string jsonDatas)
        {
            System.IO.File.WriteAllText(frontWebFileNamePath, jsonDatas);
            System.IO.File.WriteAllText(backWebFileNamePath, jsonDatas);
        }
    }
}


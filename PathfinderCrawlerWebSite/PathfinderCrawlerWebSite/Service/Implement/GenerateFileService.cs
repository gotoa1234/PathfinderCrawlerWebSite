﻿using HtmlAgilityPack;
using Newtonsoft.Json;
using NUglify;
using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.Models;
using PathfinderCrawlerWebSite.Models.Magic;
using PathfinderCrawlerWebSite.Service.IService;

namespace PathfinderCrawlerWebSite.Service.Implement
{
    public class GenerateFileService : IGenerateFileService
    {
        private readonly string frontWebSaveFilePath = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).FullName}\PF2EWebSiteFrontend\WebSite\assets\extend\Jsonfile\";
        private readonly string frontWebSaveHtmlFilePath = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).FullName}\PF2EWebSiteFrontend\WebSite\";
        private readonly string backWebSaveFilePath = $@".\wwwroot\extend\Jsonfile\";
        private readonly string backWebSaveHtmlFilePath = $@".\wwwroot\extend\htmlfile\";
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
            var getResult= _facadeMaigcService.IntergrationWorking();
            GeneratorSpellModelFile(getResult.indexedDBJson);
            GeneratorHtmlTemplate(getResult.htmlString);

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
        /// 產生 Html 樣板
        /// </summary>
        /// <param name="htmlString"></param>
        private void GeneratorHtmlTemplate(string htmlString)
        {
            // 原版
            var frontWebFileNamePath = $@"{frontWebSaveHtmlFilePath}spellHtml.html";
            var backWebFileNamePath = $@"{backWebSaveHtmlFilePath}spellHtml.html"; ;
            SaveFile(frontWebFileNamePath, backWebFileNamePath, htmlString);

            // Minify 版本
            frontWebFileNamePath = $@"{frontWebSaveHtmlFilePath}minifySpellHtml.html";
            backWebFileNamePath = $@"{backWebSaveHtmlFilePath}minifySpellHtml.html"; ;
            SaveFile(frontWebFileNamePath, backWebFileNamePath, MinifyHtml(htmlString));

            //精簡化代碼
            string MinifyHtml(string html)
            {
                var resultMinify = Uglify.Html(html).Code;
                return resultMinify;
            }
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

            //SaveFile(frontWebFileNamePath, backWebFileNamePath, jsonString);
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


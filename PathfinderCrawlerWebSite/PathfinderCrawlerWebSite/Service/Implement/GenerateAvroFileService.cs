using Avro;
using Avro.Generic;
using Avro.IO;
using Newtonsoft.Json;
using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.Models.Magic;

namespace PathfinderCrawlerWebSite.Service.Implement
{
    public class GenerateAvroFileService : IGenerateAvroFileService
    {
        private readonly int _version = 1;

        /// <summary>
        /// 產生 Avro 格式檔案
        /// </summary>
        public void GeneratorAvroFile()
        {
            // 產生版本號
            GeneratorMD5VersionAvroFile();
        }

        /// <summary>
        /// 產生法術資料檔案(奧術、神術、異能、原能)
        /// </summary>
        public void GeneratorSpellModelAvroFile(List<SpellModel> datas)
        {            
            var webSaveFilePath = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).FullName}\PF2EWebSiteFrontend\WebSite\assets\extend\Jsonfile\{nameof(SpellModel)}.json";
            var jsonString = JsonConvert.SerializeObject(datas);
            System.IO.File.WriteAllText(webSaveFilePath, jsonString);
        }

        /// <summary>
        /// 產生版本號檔案
        /// </summary>
        /// <returns></returns>
        private void GeneratorMD5VersionAvroFile()
        {
            string versionFileName = $@"{nameof(Version)}.avro";

            // 整数转字节
            var input = _version;
            byte[] inputBytes = BitConverter.GetBytes(input);

            #region .avro 產出

            // 讀取來源 .avsc 定義檔
            var schemaJson = File.ReadAllText($@".\Avro\{nameof(Version)}.avsc");
            var schema = (FixedSchema)Avro.Schema.Parse(schemaJson);

            using (var memoryStream = new MemoryStream())
            {
                // 產生.avro 內容                    
                var newItem = new GenericFixed(schema);
                newItem.Value = inputBytes;

                // 写入内存中
                var writer = new BinaryEncoder(memoryStream);
                var avroWriter = new GenericDatumWriter<GenericFixed>(schema);
                avroWriter.Write(newItem, writer);

                // 存成文件
                memoryStream.Seek(0, SeekOrigin.Begin);
                var filePath = Path.Combine("wwwroot/", versionFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }

            #endregion

        }
    }
}

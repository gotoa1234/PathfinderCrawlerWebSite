using Avro;
using Avro.Generic;
using Avro.IO;
using PathfinderCrawlerWebSite.IService;

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
            // 创建 Avro Schema
            var schemaJson = File.ReadAllText(@".\Avro\User.avsc");

            // 创建 Avro 序列化器
            var schema = (RecordSchema)Avro.Schema.Parse(schemaJson);
            // Create a memory stream to write Avro data

            using (var memoryStream = new MemoryStream())
            {
                // Create a GenericRecord instance
                var person = new GenericRecord(schema);
                person.Add("Name", "John Doe");
                person.Add("Id", 1);
                //person["Name"] = "John Doe";
                //person["Age"] = 30;

                // Serialize the GenericRecord instance to the memory stream                
                var writer = new BinaryEncoder(memoryStream);
                var avroWriter = new GenericDatumWriter<GenericRecord>(schema);
                avroWriter.Write(person, writer);

                // Save the memory stream to a file
                memoryStream.Seek(0, SeekOrigin.Begin);
                var filePath = Path.Combine("wwwroot/", "test.avro");
                //var filePath = Path.Combine(Path.GetTempPath(), "person.avro");
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    memoryStream.CopyTo(fileStream);
                }

                //var filePath = Path.Combine("wwwroot/", DateTime.Now.ToString("yyyyMMDDHHmmss") + ".avro");
                //using (var stream = new FileStream(filePath, FileMode.Create))
                //{
                //    file.CopyToAsync(stream);
                //}

                //return File(System.IO.File.ReadAllBytes(filePath), "application/avro", "person.avro");
            }

            //var serializer = new AvroSerializer<User>();

            //// 创建 User 实例
            //var user = new User { Id = 1, Name = "John" };

            //// 序列化 User 实例
            //using (var ms = new MemoryStream())
            //{
            //    serializer.Serialize(ms, user);
            //    ms.Seek(0, SeekOrigin.Begin);

            //    // 返回 Avro 文件
            //    return File(ms, "application/octet-stream", "user.avro");
            //}

            // 產生版本號
            GeneratorMD5VersionAvroFile();
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

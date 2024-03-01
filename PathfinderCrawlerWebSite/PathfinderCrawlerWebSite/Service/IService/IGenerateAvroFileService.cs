using PathfinderCrawlerWebSite.Models.Magic;

namespace PathfinderCrawlerWebSite.IService
{
    public interface IGenerateAvroFileService
    {
        void GeneratorSpellModelAvroFile(List<SpellModel> datas);
    }
}

using PathfinderCrawlerWebSite.Models.Magic;

namespace PathfinderCrawlerWebSite.IService.Magic.Root
{
    public interface IMagicRoots
    {
        List<SpellModel> Trick();
        List<SpellModel> LevelFirstSpell();
        List<SpellModel> LevelSecondSpell();
        List<SpellModel> LevelThirdSpell();
        List<SpellModel> LevelFourthSpell();
        List<SpellModel> LevelFifthSpell();
        List<SpellModel> LevelSixthSpell();
        List<SpellModel> LevelSeventhSpell();
        List<SpellModel> LevelEighthSpell();
        List<SpellModel> LevelNighthSpell();
        List<SpellModel> LevelTenthSpell();
    }
}

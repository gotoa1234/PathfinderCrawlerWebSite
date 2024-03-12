using Newtonsoft.Json;
using PathfinderCrawlerWebSite.Common;
using PathfinderCrawlerWebSite.IService.Magic;
using PathfinderCrawlerWebSite.Models.Magic;
using PathfinderCrawlerWebSite.Service.IService;

namespace PathfinderCrawlerWebSite.Service.Implement
{
    public class FacadeMaigcService : IFacadeMaigcService
    {
        private IArcaneSpellsService _arcaneSpellsService;
        private IDivineSpellsService _divineSpellsService;
        private IOccultSpellsService _occultSpellsService;
        private IPrimalSpellsService _primalSpellsService;

        public FacadeMaigcService(IArcaneSpellsService arcaneSpellsService,
            IDivineSpellsService divineSpellsService,
            IOccultSpellsService occultSpellsService,
            IPrimalSpellsService primalSpellsService)
        {
            _arcaneSpellsService = arcaneSpellsService;
            _divineSpellsService = divineSpellsService;
            _occultSpellsService = occultSpellsService;
            _primalSpellsService = primalSpellsService;
        }

        public (string htmlString, string indexedDBJson) IntergrationWorking()
        {
            var collections = new List<SpellModel>();
            // 1. 蒐集資料
            int milliSecond = 5 * 1000;//休息時間，避免太頻繁抓資料被視為異常
            try
            {
                GlobalVariable._SequenceId = 1;
                collections.AddRange(ArcaneSpellCollections());
                Thread.Sleep(milliSecond);
                collections.AddRange(DivineSpellCollections());
                Thread.Sleep(milliSecond);
                collections.AddRange(OccultSpellCollections());
                Thread.Sleep(milliSecond);
                collections.AddRange(PrimalSpellCollections());
                Thread.Sleep(milliSecond);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
            // 2. 整理資料
            var getResult =CreateData(collections);
            return (getResult.htmlString, getResult.indexedDBJson);
        }

        private List<SpellModel> ArcaneSpellCollections()
        {
            var collections = new List<SpellModel>();
            collections.AddRange(_arcaneSpellsService.Trick());
            collections.AddRange(_arcaneSpellsService.LevelFirstSpell());
            collections.AddRange(_arcaneSpellsService.LevelSecondSpell());
            collections.AddRange(_arcaneSpellsService.LevelThirdSpell());
            collections.AddRange(_arcaneSpellsService.LevelFourthSpell());
            collections.AddRange(_arcaneSpellsService.LevelFifthSpell());
            collections.AddRange(_arcaneSpellsService.LevelSixthSpell());
            collections.AddRange(_arcaneSpellsService.LevelSeventhSpell());
            collections.AddRange(_arcaneSpellsService.LevelEighthSpell());
            collections.AddRange(_arcaneSpellsService.LevelNighthSpell());
            collections.AddRange(_arcaneSpellsService.LevelTenthSpell());
            return collections;
        }

        private List<SpellModel> DivineSpellCollections()
        {
            var collections = new List<SpellModel>();
            collections.AddRange(_divineSpellsService.Trick());
            collections.AddRange(_divineSpellsService.LevelFirstSpell());
            collections.AddRange(_divineSpellsService.LevelSecondSpell());
            collections.AddRange(_divineSpellsService.LevelThirdSpell());
            collections.AddRange(_divineSpellsService.LevelFourthSpell());
            collections.AddRange(_divineSpellsService.LevelFifthSpell());
            collections.AddRange(_divineSpellsService.LevelSixthSpell());
            collections.AddRange(_divineSpellsService.LevelSeventhSpell());
            collections.AddRange(_divineSpellsService.LevelEighthSpell());
            collections.AddRange(_divineSpellsService.LevelNighthSpell());
            collections.AddRange(_divineSpellsService.LevelTenthSpell());
            return collections;
        }

        private List<SpellModel> OccultSpellCollections()
        {
            var collections = new List<SpellModel>();
            collections.AddRange(_occultSpellsService.Trick());
            collections.AddRange(_occultSpellsService.LevelFirstSpell());
            collections.AddRange(_occultSpellsService.LevelSecondSpell());
            collections.AddRange(_occultSpellsService.LevelThirdSpell());
            collections.AddRange(_occultSpellsService.LevelFourthSpell());
            collections.AddRange(_occultSpellsService.LevelFifthSpell());
            collections.AddRange(_occultSpellsService.LevelSixthSpell());
            collections.AddRange(_occultSpellsService.LevelSeventhSpell());
            collections.AddRange(_occultSpellsService.LevelEighthSpell());
            collections.AddRange(_occultSpellsService.LevelNighthSpell());
            collections.AddRange(_occultSpellsService.LevelTenthSpell());
            return collections;
        }

        private List<SpellModel> PrimalSpellCollections()
        {
            var collections = new List<SpellModel>();
            collections.AddRange(_primalSpellsService.Trick());
            collections.AddRange(_primalSpellsService.LevelFirstSpell());
            collections.AddRange(_primalSpellsService.LevelSecondSpell());
            collections.AddRange(_primalSpellsService.LevelThirdSpell());
            collections.AddRange(_primalSpellsService.LevelFourthSpell());
            collections.AddRange(_primalSpellsService.LevelFifthSpell());
            collections.AddRange(_primalSpellsService.LevelSixthSpell());
            collections.AddRange(_primalSpellsService.LevelSeventhSpell());
            collections.AddRange(_primalSpellsService.LevelEighthSpell());
            collections.AddRange(_primalSpellsService.LevelNighthSpell());
            collections.AddRange(_primalSpellsService.LevelTenthSpell());
            return collections;
        }

        /// <summary>
        /// 產生資料
        /// </summary>
        /// <returns></returns>
        private (string htmlString, string indexedDBJson) CreateData(List<SpellModel> collects)
        {
            var generateItems = new List<IndexedDBSpellModel>();
            var htmlResult = new List<string>();
            
            foreach (var item in collects)
            {                
                var newItem = new IndexedDBSpellModel();
                newItem.SpellLevel = item.SpellLevel;
                newItem.SpellClass = item.SpellClass;
                newItem.Name = item.Name;
                newItem.HtmlId = $@"{item.SpellClass}_{item.SpellLevel}_{item.Id}";
                generateItems.Add(newItem);

                var sourceRegion = item.Source.Length == 0 ? "" :
                                  $@"<tr>
										<td>{item.Source[0]}：</td>
										<td>{item.Source[1]}</td>
									</tr>
";
                var postureRegion = item.Posture.Length == 0 ? "" :
                                  $@"<tr>
										<td>{item.Posture[0]}：</td>
										<td>{item.Posture[1]}</td>
									</tr>
";
                var rangeRegion = item.Range.Length == 0 ? "" :
                                  $@"<tr>
										<td>{item.Range[0]}：</td>
										<td>{item.Range[1]}</td>
									</tr>
";
                var savingThrowsRegion = item.SavingThrows.Length == 0 ? "" :
                                  $@"<tr>
										<td>{item.SavingThrows[0]}：</td>
										<td>{item.SavingThrows[1]}</td>
									</tr>
";
                var durationRegion = item.Duration.Length == 0 ? "" :
                                  $@"<tr>
										<td>{item.Duration[0]}：</td>
										<td>{item.Duration[1]}</td>
									</tr>
";
                var ambitRegion = item.Ambit.Length == 0 ? "" :
                                  $@"<tr>
										<td>{item.Ambit[0]}：</td>
										<td>{item.Ambit[1]}</td>
									</tr>
";
                var bootRegion = item.SpellBoots.Length == 0 ? "" :
                                  $@"<!-- 增強 -->
					                 <section>
					                 	<h4>升階說明：</h4>
					                 	<blockquote>
					                 		{item.SpellBoots}
					                 	</blockquote>
					                 </section>
";

                string htmlTemplate = 
                    @$"
                <article id='{newItem.HtmlId}'>
					<section>
						<h6 class='icon solid fa-hourglass-start'>{item.SpellClassName}-{item.SpellLevelName}</h6>
						<ul class='actions'>
							<li><a href='#' class='button icon solid fas fa-chevron-left'></a></li>
							<li>
								<select name='spellitem-category' id='spellitem-category'>
									<option value='0'></option>									
								</select>
							</li>
							<li><a href='#' class='button icon solid fas fa-chevron-right'></a></li>
						</ul>
					</section>
					<hr>
					<section>
						<h1 style='white-space: pre-wrap'>{item.Name}</h1>
					</section>
					<hr>
					<section>
						<div class='fields'>
							<div class='field'>
								<h2>環級：{item.SpellLevelName}</h2>
							</div>
							<div class='field'>
								<ul>
									<li>{string.Join(" ", item.Feature)}</li>
								</ul>
							</div>
						</div>
					</section>
					<!-- 特性 -->
					<section>
						<div class='table-wrapper'>
							<table class='alt'>
								<tbody>
									{sourceRegion}
									{postureRegion}
									{rangeRegion}
									{savingThrowsRegion}
									{durationRegion}
									{ambitRegion}
								</tbody>
							</table>
						</div>
					</section>
					<!-- 說明 -->
					<section>
						<h4>技能說明：</h4>
						<blockquote>
							{item.Explain}
						</blockquote>
					</section>
					{bootRegion}
                </article>
";
                htmlResult.Add(htmlTemplate);
            }

            var htmlFile = string.Join(Environment.NewLine, htmlResult);
            var indexedDbJsonFile = JsonConvert.SerializeObject(generateItems);
            return (htmlFile, indexedDbJsonFile);
        }

    }
}

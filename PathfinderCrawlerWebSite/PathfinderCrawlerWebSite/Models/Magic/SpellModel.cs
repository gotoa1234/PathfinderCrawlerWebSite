using HtmlAgilityPack;
using PathfinderCrawlerWebSite.Common;
using System.ComponentModel;

namespace PathfinderCrawlerWebSite.Models.Magic
{
    public class SpellModel
    {
        /// <summary>
        /// 種類 Arcane / Divine / Occult / Primal
        /// </summary>
        public string SpellClass { get; set;}

        /// <summary>
        /// 階級
        /// </summary>
        public string SpellLevel { get; set; } = string.Empty;

        /// <summary>
        /// 資料來源 URL
        /// </summary>
        public string SourceDataUrl { get; set; } = string.Empty;

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 等級
        /// </summary>
        public int Level { get; set; } = 1;

        /// <summary>
        /// 特性
        /// </summary>
        [Description("//div[2]/span")]
        public string[] Feature { get; set; } = Array.Empty<string>();

        #region 動作
        /// <summary>
        /// 根源
        /// </summary>
        public string[] Source { get; set; } = Array.Empty<string>();

        /// <summary>
        /// 施放
        /// </summary>
        public string[] Posture { get; set; } = Array.Empty<string>();

        /// <summary>
        /// 射程
        /// </summary>
        public string[] Range { get; set; } = Array.Empty<string>();

        /// <summary>
        /// 豁免
        /// </summary>
        public string[] SavingThrows{ get; set; } = Array.Empty<string>();

        /// <summary>
        /// 區域
        /// </summary>
        public string[] Ambit { get; set; } = Array.Empty<string>();

        /// <summary>
        /// 持續時間
        /// </summary>
        public string[] Duration { get; set; } = Array.Empty<string>();
        #endregion

        /// <summary>
        /// 說明
        /// </summary>
        public string Explain { get; set; }

        /// <summary>
        /// 升階
        /// </summary>
        public string SpellBoots { get; set; }

        public SpellModel(HtmlNode xmlNode, 
            string className, 
            string level,
            string sourceDataUrl)
        {
            // 每個資料都應該有自己的處理方式
            this.SpellClass = className;
            this.SpellLevel= level;
            this.SourceDataUrl = sourceDataUrl;
            this.Name = GetName();
            // 檢核資料是否正確格式，如果正確 Name 應有值
            if (!string.IsNullOrEmpty(this.Name))
            {
                this.Level = GetLevel();
                this.Feature = GetFeature();
                SetUseMethod();
                this.Explain = GetExplain();
                this.SpellBoots = GetSpellBoots();
            }

            string GetName(string path = "./div[1]/span[1]")
            {                
                return xmlNode.SelectSingleNode(path) == null 
                    ? String.Empty 
                    : xmlNode.SelectSingleNode(path).InnerText;                
            }

            int GetLevel(string path = "./div[1]/span[2]")
            {                
                var text = xmlNode.SelectSingleNode(path).InnerText;
                var getText = new string(text.Where(char.IsDigit).ToArray());
                return getText.Length > 0 ? int.Parse(getText) : 1;
            }

            string[] GetFeature(string path = "./div[2]")
            {
                var text = xmlNode.SelectSingleNode(path).InnerHtml;
                var tempDoc = new HtmlDocument();
                tempDoc.LoadHtml(text);
                var tempNodes = tempDoc.DocumentNode.SelectNodes("//span");
                return tempNodes?.Select(node => node.InnerText).ToArray() ?? new string[0];
            }

            void SetUseMethod(string path = "./table[1]/tbody[1]")
            {                
                var text = xmlNode.SelectSingleNode(path).InnerHtml;
                var tempDoc = new HtmlDocument();
                tempDoc.LoadHtml(text);
                HtmlNodeCollection nodes = tempDoc.DocumentNode.SelectNodes("//tr");
                foreach (HtmlNode node in nodes)
                {
                    HtmlNode thNode = node.SelectSingleNode("th");
                    HtmlNode tdNode = node.SelectSingleNode("td");
                    if (thNode != null && tdNode != null)
                    {
                        string thText = thNode.InnerText.Trim();
                        string tdText = tdNode.InnerText.Trim();

                        switch (thText)
                        {
                            case UseSpellMethodEnum.Source:
                                this.Source = new string[2];
                                this.Source[0] = thText;
                                this.Source[1] = tdText;
                                break;
                            case UseSpellMethodEnum.Posture:
                                this.Posture = new string[2];
                                this.Posture[0] = thText;
                                this.Posture[1] = tdText;
                                break;
                            case UseSpellMethodEnum.Range:
                                this.Range = new string[2];
                                this.Range[0] = thText;
                                this.Range[1] = tdText;
                                break;
                            case UseSpellMethodEnum.SavingThrows:
                                this.SavingThrows = new string[2];
                                this.SavingThrows[0] = thText;
                                this.SavingThrows[1] = tdText;
                                break;
                            case UseSpellMethodEnum.Ambit:
                                this.Ambit = new string[2];
                                this.Ambit[0] = thText;
                                this.Ambit[1] = tdText;
                                break;
                            case UseSpellMethodEnum.Duration:
                                this.Duration = new string[2];
                                this.Duration[0] = thText;
                                this.Duration[1] = tdText;
                                break;
                        }                
                    }
                }
            }

            string GetExplain(string path = "./div[3]")
            {
                return xmlNode.SelectSingleNode(path).OuterHtml;
            }

            string GetSpellBoots(string path = "./div[4]")
            {
                return xmlNode.SelectSingleNode(path)?.OuterHtml ?? String.Empty;
            }
        }
    }
}

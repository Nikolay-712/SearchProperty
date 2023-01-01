using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SearchProperty.Data.Seeding.Scraping
{
    public class TownScraper : ITownScraper
    {
        public Dictionary<string, List<string>> GetTowns()
        {
            var requestUriString = "https://www.nsi.bg/en/content/2981/population-towns-and-sex";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            HtmlDocument doc = new HtmlDocument();
            doc.Load(response.GetResponseStream());

            HtmlNode table = doc.DocumentNode.SelectSingleNode("//table[@class='nsit2']");
            var tableBody = table.SelectNodes("//tbody//tr//td")
                .Where(x => x.OuterHtml.Contains("class=\"boldt\"") ||
                x.OuterHtml.Contains("class=\"left_top\"")).Skip(1);

            var towns = new Dictionary<string, List<string>>();
            string townName = string.Empty;

            foreach (var item in tableBody)
            {
                if (item.OuterHtml.Contains("class=\"boldt\""))
                {
                    townName = item.InnerHtml.Trim();
                }

                if (!towns.ContainsKey(townName) && item.OuterHtml.Contains("class=\"boldt\""))
                {
                    towns[townName] = new List<string>();
                }

                if (item.OuterHtml.Contains("class=\"left_top\""))
                {
                    var town = item.InnerHtml.Trim();
                    towns[townName].Add(town);
                }
            }

            return towns;
        }
    }
}

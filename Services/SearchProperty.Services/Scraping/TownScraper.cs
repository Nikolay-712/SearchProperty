namespace SearchProperty.Services.Scraping
{
    using System.Collections.Generic;
    using System.Net;

    using HtmlAgilityPack;

    public class TownScraper : ITownScraper
    {
        public void GetTowns()
        {
            var requestUriString = "https://www.nsi.bg/en/content/2981/population-towns-and-sex";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            HtmlDocument doc = new HtmlDocument();
            doc.Load(response.GetResponseStream());

            HtmlNode table = doc.DocumentNode.SelectSingleNode("//table[@class='nsit2']");

            var districtTowns = doc.DocumentNode.SelectNodes("//td[@class='boldt']");
            var townCell1 = doc.DocumentNode.SelectNodes("//td[@class='left_top']");

            List<string> towns = new List<string>();
            foreach (var row in districtTowns)
            {
                string townName = row.InnerHtml.Trim();
                towns.Add(townName);
            }
        }
    }
}

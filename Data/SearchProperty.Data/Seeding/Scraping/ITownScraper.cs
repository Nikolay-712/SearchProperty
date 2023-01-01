namespace SearchProperty.Data.Seeding.Scraping
{
    using System.Collections.Generic;

    public interface ITownScraper
    {
        Dictionary<string, List<string>> GetTowns();
    }
}

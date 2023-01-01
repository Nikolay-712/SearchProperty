namespace SearchProperty.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using SearchProperty.Data.Models.Addresses;
    using SearchProperty.Data.Seeding.Scraping;

    public class TownSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.RegionalTowns.Any())
            {
                return;
            }

            var townScraper = serviceProvider.GetRequiredService<ITownScraper>();
            var townsScraping = townScraper.GetTowns();

            var regionalTowns = new List<RegionalTown>();
            var towns = new List<Town>();

            foreach (var town in townsScraping)
            {
                var regionalTown = new RegionalTown { Name = town.Key, IsRegionalTown = true, };

                foreach (var item in town.Value)
                {
                    towns.Add(new Town { Name = item, RegionalTownId = regionalTown.Id, });
                }

                regionalTowns.Add(regionalTown);
            }

            await dbContext.RegionalTowns.AddRangeAsync(regionalTowns);
            await dbContext.Towns.AddRangeAsync(towns);
        }
    }
}

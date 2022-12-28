namespace SearchProperty.Web.Controllers.Search
{
    using Microsoft.AspNetCore.Mvc;
    using SearchProperty.Data.Models.OfferedProperties.Enums;
    using SearchProperty.Services.Search;
    using SearchProperty.Web.ViewModels.Search;
    using System.Collections.Generic;

    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        //public IActionResult Index()
        //{
        //    return this.View();
        //}

        public IActionResult Index()
        {
            SearchInputModel searchInput = new SearchInputModel
            {
                Town = "Sofia",
                Type = PropertyType.Residential,
                ForRent = false,
                PropertyType = new List<string> { "House", "Apartment" },
            };


            var properties = this.searchService.PropertiesByFilters(searchInput);
            return this.View(properties);
        }
    }
}

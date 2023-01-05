namespace SearchProperty.Web.Controllers.Search
{
    using Microsoft.AspNetCore.Mvc;
    using SearchProperty.Services.Search;
    using SearchProperty.Web.ViewModels.Search;

    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult Index()
        {
            var searchInput = this.searchService.GetAllTowns();
            return this.View(searchInput);
        }

        public IActionResult Result(SearchInputModel searchInput)
        {
            var properties = this.searchService.PropertiesByFilters(searchInput);
            return this.View(properties);
        }
    }
}

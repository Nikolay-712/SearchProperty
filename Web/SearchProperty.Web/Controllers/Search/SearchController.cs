namespace SearchProperty.Web.Controllers.Search
{
    using Microsoft.AspNetCore.Mvc;
    using SearchProperty.Services.Search;
    using SearchProperty.Web.ViewModels.OfferedProperties;

    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult AllProperties()
        {
            var properties = this.searchService.AllProperties<PropertyViewModel>();
            return this.View();
        }
    }
}

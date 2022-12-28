namespace SearchProperty.Services.Search
{
    using System.Collections.Generic;
    using System.Linq;

    using SearchProperty.Web.ViewModels.OfferedProperties;
    using SearchProperty.Web.ViewModels.Search;

    public interface ISearchService
    {
        IQueryable<T> AllProperties<T>();

        IEnumerable<PropertyViewModel> PropertiesByFilters(SearchInputModel searchInput);
    }
}

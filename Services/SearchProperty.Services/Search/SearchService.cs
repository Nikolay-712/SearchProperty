namespace SearchProperty.Services.Search
{
    using System.Collections.Generic;
    using System.Linq;

    using SearchProperty.Data;
    using SearchProperty.Data.Models.Addresses;
    using SearchProperty.Services.Mapping;
    using SearchProperty.Web.ViewModels.Addresses;
    using SearchProperty.Web.ViewModels.OfferedProperties;
    using SearchProperty.Web.ViewModels.Search;

    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SearchService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IQueryable<T> AllProperties<T>()
        {
            var properties = this.applicationDbContext.Properties.To<T>();
            return properties;
        }

        public SearchInputModel GetAllTowns()
        {
            return new SearchInputModel
            {
                AllTowns = this.applicationDbContext
                 .RegionalTowns
                 .To<TownViewModel>()
                 .OrderBy(x => x.Name)
                 .ToList(),
            };
        }

        public IEnumerable<PropertyViewModel> PropertiesByFilters(SearchInputModel searchInput)
        {
            var all = this.AllProperties<PropertyViewModel>();
            var aaa = new List<PropertyViewModel>();

            var search = all
                .Where(x => x.Town == searchInput.Town)
                .Where(x => x.ForRent == searchInput.ForRent)
                .Where(x => x.PropertyType == searchInput.Type)
                .ToList();

            if (searchInput.PropertyType != null)
            {
                foreach (var type in searchInput.PropertyType)
                {
                    var tempSearch = search
                        .Where(x => x.ResidentalDetails != null ?
                            x.ResidentalDetails.ResidentialTypes.ToString() == type :
                            x.BusinessDetails.BusinessType.ToString() == type).ToList();

                    aaa.Concat(tempSearch);
                }
            }

            return search;
        }
    }
}

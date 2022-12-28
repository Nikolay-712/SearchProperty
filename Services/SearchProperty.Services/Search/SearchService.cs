namespace SearchProperty.Services.Search
{
    using System.Collections.Generic;
    using System.Linq;

    using SearchProperty.Data;
    using SearchProperty.Services.Mapping;
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

        public IEnumerable<PropertyViewModel> PropertiesByFilters(SearchInputModel searchInput)
        {
            var all = this.AllProperties<PropertyViewModel>();
            var tempPropertiesList = new List<PropertyViewModel>();

            var search = all
                .Where(x => x.PropertyType == searchInput.Type)
                .Where(x => x.Town == searchInput.Town)
                .Where(x => x.ForRent == searchInput.ForRent);


            if (searchInput.PropertyType != null)
            {
                foreach (var type in searchInput.PropertyType)
                {
                    search
                        .Where(x => x.ResidentalDetails != null ?
                         x.ResidentalDetails.ResidentialTypes.ToString() == type :
                         x.BusinessDetails.BusinessType.ToString() == type);

                    tempPropertiesList.AddRange(search);
                }
            }

            return search;
        }
    }
}

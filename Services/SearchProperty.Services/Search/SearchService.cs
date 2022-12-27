namespace SearchProperty.Services.Search
{
    using System.Collections.Generic;

    using SearchProperty.Data;
    using SearchProperty.Services.Mapping;

    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SearchService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<T> AllProperties<T>()
        {
            var properties = this.applicationDbContext.Properties.To<T>();
            return properties;
        }
    }
}

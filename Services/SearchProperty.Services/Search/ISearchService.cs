namespace SearchProperty.Services.Search
{
    using System.Collections.Generic;

    public interface ISearchService
    {
        IEnumerable<T> AllProperties<T>();
    }
}

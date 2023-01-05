namespace SearchProperty.Web.ViewModels.Addresses
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using SearchProperty.Data.Models.Addresses;
    using SearchProperty.Services.Mapping;

    public class TownViewModel : IMapFrom<RegionalTown>, IHaveCustomMappings
    {
        public string Id { get; init; }

        public string Name { get; init; }

        public bool IsRegionalTown { get; init; }

        public IEnumerable<string> Towns { get; init; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<RegionalTown, TownViewModel>()
                .ForMember(x => x.Towns, opt =>
                    opt.MapFrom(x => x.Towns.Select(x => x.Name)));
        }
    }
}

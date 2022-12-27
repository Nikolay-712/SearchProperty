namespace SearchProperty.Web.ViewModels.OfferedProperties
{
    using System;

    using AutoMapper;

    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Data.Models.OfferedProperties.Enums;
    using SearchProperty.Services.Mapping;

    public class PropertyViewModel : IMapFrom<Property>, IHaveCustomMappings
    {
        public string Id { get; init; }

        public DateTime CreatedOn { get; init; }

        public PropertyType PropertyType { get; init; }

        public decimal Price { get; init; }

        public string Description { get; init; }

        public int SquareMeters { get; init; }

        public bool ForRent { get; init; }

        public string Town { get; init; }

        public string FullAddress { get; init; }

        public ResidentalDetailsViewModel ResidentalDetails { get; init; }

        public BusinessDetailsViewModel BusinessDetails { get; init; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Property, PropertyViewModel>()
                .ForMember(x => x.Town, opt =>
                    opt.MapFrom(x => x.Address.Town))
                .ForMember(x => x.FullAddress, opt =>
                    opt.MapFrom(x => x.Address.FullAddress));
        }
    }
}

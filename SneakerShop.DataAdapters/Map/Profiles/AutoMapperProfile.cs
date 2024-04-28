using AutoMapper;

namespace SneakerShop.DataAdapters.Map.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            foreach (var map in MapLinks.MappedTypes)
                CreateMap(map.SourceType, map.DestinationType);

            var mutualMaps = MapLinks.MappedTypes.Where(x => x.IsMutual).Select(x => x.SwapTypes());
            foreach (var map in mutualMaps)
                CreateMap(map.SourceType, map.DestinationType);

            CreateMap<DataAdapters.Contracts.Models.Entities.BasketElement, Core.Models.Entities.BasketElement>();
            CreateMap<Core.Models.Entities.Discount, DataAdapters.Contracts.Models.Entities.Discount>();
            CreateMap<DataAdapters.Contracts.Models.Entities.Discount, Core.Models.Entities.Discount>();
            CreateMap<Core.Models.Entities.DiscountType, DataAdapters.Contracts.Models.Entities.DiscountType>();
            CreateMap<DataAdapters.Contracts.Models.Entities.DiscountType, Core.Models.Entities.DiscountType>();
            CreateMap<Core.Models.Entities.Good, DataAdapters.Contracts.Models.Entities.Good>();
            CreateMap<DataAdapters.Contracts.Models.Entities.Good, Core.Models.Entities.Good>();
            CreateMap<Core.Models.Entities.GoodSubtype, DataAdapters.Contracts.Models.Entities.GoodSubtype>();
            CreateMap<DataAdapters.Contracts.Models.Entities.GoodSubtype, Core.Models.Entities.GoodSubtype>();
            CreateMap<Core.Models.Entities.GoodType, DataAdapters.Contracts.Models.Entities.GoodType>();
            CreateMap<DataAdapters.Contracts.Models.Entities.GoodType, Core.Models.Entities.GoodType>();
            CreateMap<Core.Models.Entities.Manufacturer, DataAdapters.Contracts.Models.Entities.Manufacturer>();
            CreateMap<DataAdapters.Contracts.Models.Entities.Manufacturer, Core.Models.Entities.Manufacturer>();
            CreateMap<Core.Models.Entities.Order, DataAdapters.Contracts.Models.Entities.Order>();
            CreateMap<DataAdapters.Contracts.Models.Entities.Order, Core.Models.Entities.Order>();
            CreateMap<Core.Models.Entities.OrderedGood, DataAdapters.Contracts.Models.Entities.OrderedGood>();
            CreateMap<DataAdapters.Contracts.Models.Entities.OrderedGood, Core.Models.Entities.OrderedGood>();
            CreateMap<Core.Models.Entities.Size, DataAdapters.Contracts.Models.Entities.Size>();
            CreateMap<DataAdapters.Contracts.Models.Entities.Size, Core.Models.Entities.Size>();
            CreateMap<Core.Models.Auth.AppUser, DataAdapters.Contracts.Models.Entities.AppUser>();
            CreateMap<DataAdapters.Contracts.Models.Entities.AppUser, Core.Models.Auth.AppUser>();
        }
    }
}
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
        }
    }
}
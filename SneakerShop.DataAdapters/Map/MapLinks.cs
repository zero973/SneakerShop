namespace SneakerShop.DataAdapters.Map
{
    public static class MapLinks
    {

        public static HashSet<MapParams> MappedTypes = new HashSet<MapParams>() 
        {  
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.Discount), typeof(Models.Entities.Discount), true),
            new MapParams(typeof(Core.Models.Entities.DiscountType), typeof(Models.Entities.DiscountType), true),
            new MapParams(typeof(Core.Models.Entities.Good), typeof(Models.Entities.Good), true),
            new MapParams(typeof(Core.Models.Entities.GoodSubtype), typeof(Models.Entities.GoodSubtype), true),
            new MapParams(typeof(Core.Models.Entities.GoodType), typeof(Models.Entities.GoodType), true),
            new MapParams(typeof(Core.Models.Entities.Manufacturer), typeof(Models.Entities.Manufacturer), true),
            new MapParams(typeof(Core.Models.Entities.Order), typeof(Models.Entities.Order), true),
            new MapParams(typeof(Core.Models.Entities.OrderedGood), typeof(Models.Entities.OrderedGood), true),
            new MapParams(typeof(Core.Models.Entities.Size), typeof(Models.Entities.Size), true),
            new MapParams(typeof(Core.Models.Entities.AppUser), typeof(Models.Entities.AppUser), true)
        };

        /// <summary>
        /// Получить мапинг для заданного типа <paramref name="sourceType"/>
        /// </summary>
        public static MapParams GetMap(Type sourceType)
        {
            var result = MappedTypes.Single(x => 
                x.SourceType == sourceType || x.IsMutual && x.DestinationType == sourceType);

            if (result.IsMutual && result.DestinationType == sourceType)
                result = result.SwapTypes();

            return result;
        }

    }
}
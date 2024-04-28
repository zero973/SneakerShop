namespace SneakerShop.DataAdapters.Map
{
    public static class MapLinks
    {

        public static HashSet<MapParams> MappedTypes = new HashSet<MapParams>() 
        {  
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true),
            new MapParams(typeof(Core.Models.Entities.BasketElement), typeof(DataAdapters.Contracts.Models.Entities.BasketElement), true)
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
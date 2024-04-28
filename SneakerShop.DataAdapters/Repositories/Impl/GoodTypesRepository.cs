using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class GoodTypesRepository : BaseDbEntitiesRepository<Core.Models.Entities.GoodType, Models.Entities.GoodType>
    {
        public GoodTypesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
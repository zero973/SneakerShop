using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class GoodSubtypesRepository : BaseDbEntitiesRepository<Core.Models.Entities.GoodSubtype, Models.Entities.GoodSubtype>
    {
        public GoodSubtypesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
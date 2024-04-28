using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class GoodsRepository : BaseDbEntitiesRepository<Core.Models.Entities.Good, Models.Entities.Good>
    {
        public GoodsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
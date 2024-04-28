using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class OrderedGoodsRepository : BaseDbEntitiesRepository<Core.Models.Entities.OrderedGood, Models.Entities.OrderedGood>
    {
        public OrderedGoodsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
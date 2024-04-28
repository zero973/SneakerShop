using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class OrdersRepository : BaseDbEntitiesRepository<Core.Models.Entities.Order, Models.Entities.Order>
    {
        public OrdersRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
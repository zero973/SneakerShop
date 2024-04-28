using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class DiscountsRepository : BaseDbEntitiesRepository<Core.Models.Entities.Discount, Models.Entities.Discount>
    {
        public DiscountsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
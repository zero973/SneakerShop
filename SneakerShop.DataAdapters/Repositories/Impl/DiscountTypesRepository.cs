using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class DiscountTypesRepository : BaseDbEntitiesRepository<Core.Models.Entities.DiscountType, Models.Entities.DiscountType>
    {
        public DiscountTypesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
using AutoMapper;
using SneakerShop.DAL.ApplicationContexts;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class DiscountTypesRepository : BaseDbEntitiesRepository<Core.Models.Entities.DiscountType, Models.Entities.DiscountType>
    {
        public DiscountTypesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
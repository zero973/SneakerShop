using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class BasketElementsRepository : BaseDbEntitiesRepository<Core.Models.Entities.BasketElement, Models.Entities.BasketElement>
    {
        public BasketElementsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
using AutoMapper;
using SneakerShop.DAL.ApplicationContexts;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class GoodTypesRepository : BaseDbEntitiesRepository<Core.Models.Entities.GoodType, Models.Entities.GoodType>
    {
        public GoodTypesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
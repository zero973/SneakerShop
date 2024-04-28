using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class SizesRepository : BaseDbEntitiesRepository<Core.Models.Entities.Size, Models.Entities.Size>
    {
        public SizesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
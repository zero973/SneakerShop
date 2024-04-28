using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class ManufacturersRepository : BaseDbEntitiesRepository<Core.Models.Entities.Manufacturer, Models.Entities.Manufacturer>
    {
        public ManufacturersRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
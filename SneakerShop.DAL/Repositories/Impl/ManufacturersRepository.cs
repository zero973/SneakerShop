using AutoMapper;
using SneakerShop.DAL.ApplicationContexts;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class ManufacturersRepository : BaseDbEntitiesRepository<Core.Models.Entities.Manufacturer, Models.Entities.Manufacturer>
    {
        public ManufacturersRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
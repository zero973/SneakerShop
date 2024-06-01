using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DAL.ApplicationContexts;
using SneakerShop.DAL.Models.Entities;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class OrdersRepository : BaseDbEntitiesRepository<Core.Models.Entities.Order, Order>
    {

        public OrdersRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override async Task<Core.Models.Entities.Order> Get(Guid id)
        {
            var entity = await Context.Set<Order>()
                .Include(x => x.User)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<Core.Models.Entities.Order>(entity);
        }

        public override IQueryable<Core.Models.Entities.Order> GetAll(IList<ComplexFilter> filters)
        {
            var result = Context.Set<Order>()
                .Include(x => x.User)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return Mapper.ProjectTo<Core.Models.Entities.Order>(result);
        }

    }
}
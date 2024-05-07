using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DataAdapters.ApplicationContexts;
using SneakerShop.DataAdapters.Models.Entities;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class OrdersRepository : BaseDbEntitiesRepository<Core.Models.Entities.Order, Order>
    {

        private readonly ApplicationContext _Context;

        private readonly IMapper _Mapper;

        public OrdersRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public override async Task<Core.Models.Entities.Order> Get(Guid id)
        {
            var entity = await _Context.Set<Order>()
                .Include(x => x._User)
                .SingleOrDefaultAsync(x => x.Id == id);
            return _Mapper.Map<Core.Models.Entities.Order>(entity);
        }

        public override IQueryable<Core.Models.Entities.Order> GetAll(IList<ComplexFilter> filters)
        {
            var result = _Context.Set<Order>()
                .Include(x => x._User)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return _Mapper.ProjectTo<Core.Models.Entities.Order>(result);
        }

    }
}
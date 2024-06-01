using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DAL.ApplicationContexts;
using SneakerShop.DAL.Models.Entities;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class OrderedGoodsRepository : BaseDbEntitiesRepository<Core.Models.Entities.OrderedGood, OrderedGood>
    {

        public OrderedGoodsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override async Task<Core.Models.Entities.OrderedGood> Get(Guid id)
        {
            var entity = await Context.Set<OrderedGood>()
                .Include(x => x.Order)
                .Include(x => x.Good)
                .Include(x => x.Size)
                .Include(x => x.Discount)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<Core.Models.Entities.OrderedGood>(entity);
        }

        public override IQueryable<Core.Models.Entities.OrderedGood> GetAll(IList<ComplexFilter> filters)
        {
            var result = Context.Set<OrderedGood>()
                .Include(x => x.Order)
                .Include(x => x.Good)
                .Include(x => x.Size)
                .Include(x => x.Discount)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return Mapper.ProjectTo<Core.Models.Entities.OrderedGood>(result);
        }

    }
}
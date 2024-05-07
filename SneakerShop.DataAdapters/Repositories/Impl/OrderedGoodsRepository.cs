using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DataAdapters.ApplicationContexts;
using SneakerShop.DataAdapters.Models.Entities;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class OrderedGoodsRepository : BaseDbEntitiesRepository<Core.Models.Entities.OrderedGood, OrderedGood>
    {

        private readonly ApplicationContext _Context;

        private readonly IMapper _Mapper;

        public OrderedGoodsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public override async Task<Core.Models.Entities.OrderedGood> Get(Guid id)
        {
            var entity = await _Context.Set<OrderedGood>()
                .Include(x => x._Order)
                .Include(x => x._Good)
                .Include(x => x._Size)
                .Include(x => x._Discount)
                .SingleOrDefaultAsync(x => x.Id == id);
            return _Mapper.Map<Core.Models.Entities.OrderedGood>(entity);
        }

        public override IQueryable<Core.Models.Entities.OrderedGood> GetAll(IList<ComplexFilter> filters)
        {
            var result = _Context.Set<OrderedGood>()
                .Include(x => x._Order)
                .Include(x => x._Good)
                .Include(x => x._Size)
                .Include(x => x._Discount)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return _Mapper.ProjectTo<Core.Models.Entities.OrderedGood>(result);
        }

    }
}
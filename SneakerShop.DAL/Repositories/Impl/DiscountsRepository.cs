using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DAL.ApplicationContexts;
using SneakerShop.DAL.Models.Entities;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class DiscountsRepository : BaseDbEntitiesRepository<Core.Models.Entities.Discount, Discount>
    {

        private readonly ApplicationContext _Context;

        private readonly IMapper _Mapper;

        public DiscountsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public override async Task<Core.Models.Entities.Discount> Get(Guid id)
        {
            var entity = await _Context.Set<Discount>()
                .Include(x => x._Good)
                    .ThenInclude(x => x._GoodSubtype)
                        .ThenInclude(x => x._GoodType)
                .Include(x => x._DiscountType)
                .SingleOrDefaultAsync(x => x.Id == id);
            return _Mapper.Map<Core.Models.Entities.Discount>(entity);
        }

        public override IQueryable<Core.Models.Entities.Discount> GetAll(IList<ComplexFilter> filters)
        {
            var result = _Context.Set<Discount>()
                .Include(x => x._Good)
                    .ThenInclude(x => x._GoodSubtype)
                        .ThenInclude(x => x._GoodType)
                .Include(x => x._DiscountType)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return _Mapper.ProjectTo<Core.Models.Entities.Discount>(result);
        }

    }
}
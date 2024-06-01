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

        public DiscountsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override async Task<Core.Models.Entities.Discount> Get(Guid id)
        {
            var entity = await Context.Set<Discount>()
                .Include(x => x.Good)
                    .ThenInclude(x => x.GoodSubtype)
                        .ThenInclude(x => x.GoodType)
                .Include(x => x.DiscountType)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<Core.Models.Entities.Discount>(entity);
        }

        public override IQueryable<Core.Models.Entities.Discount> GetAll(IList<ComplexFilter> filters)
        {
            var result = Context.Set<Discount>()
                .Include(x => x.Good)
                    .ThenInclude(x => x.GoodSubtype)
                        .ThenInclude(x => x.GoodType)
                .Include(x => x.DiscountType)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return Mapper.ProjectTo<Core.Models.Entities.Discount>(result);
        }

    }
}
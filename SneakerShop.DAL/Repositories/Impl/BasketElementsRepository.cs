using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DAL.ApplicationContexts;
using SneakerShop.DAL.Models.Entities;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class BasketElementsRepository : BaseDbEntitiesRepository<Core.Models.Entities.BasketElement, BasketElement>
    {

        public BasketElementsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override async Task<Core.Models.Entities.BasketElement> Get(Guid id)
        {
            var entity = await Context.Set<BasketElement>()
                .Include(x => x.Good)
                    .ThenInclude(x => x.GoodSubtype)
                        .ThenInclude(x => x.GoodType)
                .Include(x => x.Size)
                    .ThenInclude(x => x.GoodSubtype)
                .Include(x => x.User)
                .Include(x => x.Discount)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.Entities.BasketElement>(entity);
        }

        public override IQueryable<Core.Models.Entities.BasketElement> GetAll(IList<ComplexFilter> filters)
        {
            var result = Context.Set<BasketElement>()
                .Include(x => x.Good)
                    .ThenInclude(x => x.GoodSubtype)
                        .ThenInclude(x => x.GoodType)
                .Include(x => x.Size)
                    .ThenInclude(x => x.GoodSubtype)
                .Include(x => x.User)
                .Include(x => x.Discount)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return Mapper.ProjectTo<Core.Models.Entities.BasketElement>(result);
        }
    }
}
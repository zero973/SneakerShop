using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DAL.ApplicationContexts;
using SneakerShop.DAL.Models.Entities;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class GoodsRepository : BaseDbEntitiesRepository<Core.Models.Entities.Good, Good>
    {

        public GoodsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override async Task<Core.Models.Entities.Good> Get(Guid id)
        {
            var entity = await Context.Set<Good>()
                .Include(x => x.Manufacturer)
                .Include(x => x.GoodSubtype)
                .ThenInclude(x => x.GoodType)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<Core.Models.Entities.Good>(entity);
        }

        public override IQueryable<Core.Models.Entities.Good> GetAll(IList<ComplexFilter> filters)
        {
            var entity = Context.Set<Good>()
                .Include(x => x.Manufacturer)
                .Include(x => x.GoodSubtype)
                    .ThenInclude(x => x.GoodType)
                .AsQueryable();

            if (filters != null && filters.Any())
                entity = entity.WithFilters(filters);

            return Mapper.ProjectTo<Core.Models.Entities.Good>(entity);
        }

    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DAL.ApplicationContexts;
using SneakerShop.DAL.Models.Entities;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class GoodSubtypesRepository : BaseDbEntitiesRepository<Core.Models.Entities.GoodSubtype, GoodSubtype>
    {

        public GoodSubtypesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override async Task<Core.Models.Entities.GoodSubtype> Get(Guid id)
        {
            var entity = await Context.Set<GoodSubtype>()
                .Include(x => x.GoodType)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<Core.Models.Entities.GoodSubtype>(entity);
        }

        public override IQueryable<Core.Models.Entities.GoodSubtype> GetAll(IList<ComplexFilter> filters)
        {
            var result = Context.Set<GoodSubtype>()
                .Include(x => x.GoodType)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return Mapper.ProjectTo<Core.Models.Entities.GoodSubtype>(result);
        }

    }
}
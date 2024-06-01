using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DAL.ApplicationContexts;
using SneakerShop.DAL.Models.Entities;

namespace SneakerShop.DAL.Repositories.Impl
{
    public class SizesRepository : BaseDbEntitiesRepository<Core.Models.Entities.Size, Size>
    {

        public SizesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override async Task<Core.Models.Entities.Size> Get(Guid id)
        {
            var entity = await Context.Set<Size>()
                .Include(x => x.GoodSubtype)
                    .ThenInclude(x => x.GoodType)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<Core.Models.Entities.Size>(entity);
        }

        public override IQueryable<Core.Models.Entities.Size> GetAll(IList<ComplexFilter> filters)
        {
            var result = Context.Set<Size>()
                .Include(x => x.GoodSubtype)
                    .ThenInclude(x => x.GoodType)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return Mapper.ProjectTo<Core.Models.Entities.Size>(result);
        }

    }
}
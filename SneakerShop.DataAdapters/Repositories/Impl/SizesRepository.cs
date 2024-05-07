using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DataAdapters.ApplicationContexts;
using SneakerShop.DataAdapters.Models.Entities;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class SizesRepository : BaseDbEntitiesRepository<Core.Models.Entities.Size, Size>
    {

        private readonly ApplicationContext _Context;

        private readonly IMapper _Mapper;

        public SizesRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public override async Task<Core.Models.Entities.Size> Get(Guid id)
        {
            var entity = await _Context.Set<Size>()
                .Include(x => x._GoodSubtype)
                    .ThenInclude(x => x._GoodType)
                .SingleOrDefaultAsync(x => x.Id == id);
            return _Mapper.Map<Core.Models.Entities.Size>(entity);
        }

        public override IQueryable<Core.Models.Entities.Size> GetAll(IList<ComplexFilter> filters)
        {
            var result = _Context.Set<Size>()
                .Include(x => x._GoodSubtype)
                    .ThenInclude(x => x._GoodType)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return _Mapper.ProjectTo<Core.Models.Entities.Size>(result);
        }

    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.DataAdapters.ApplicationContexts;
using SneakerShop.DataAdapters.Models.Entities;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    public class GoodsRepository : BaseDbEntitiesRepository<Core.Models.Entities.Good, Good>
    {

        private readonly ApplicationContext _Context;

        private readonly IMapper _Mapper;

        public GoodsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public override async Task<Core.Models.Entities.Good> Get(Guid id)
        {
            var entity = await _Context.Set<Good>()
                .Include(x => x._Manufacturer)
                .Include(x => x._GoodSubtype)
                .ThenInclude(x => x._GoodType)
                .SingleOrDefaultAsync(x => x.Id == id);
            return _Mapper.Map<Core.Models.Entities.Good>(entity);
        }

        public override IQueryable<Core.Models.Entities.Good> GetAll(IList<ComplexFilter> filters)
        {
            var entity = _Context.Set<Good>()
                .Include(x => x._Manufacturer)
                .Include(x => x._GoodSubtype)
                    .ThenInclude(x => x._GoodType)
                .AsQueryable();

            if (filters != null && filters.Any())
                entity = entity.WithFilters(filters);

            return _Mapper.ProjectTo<Core.Models.Entities.Good>(entity);
        }

    }
}
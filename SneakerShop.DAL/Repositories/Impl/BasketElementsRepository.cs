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

        private readonly ApplicationContext _Context;

        private readonly IMapper _Mapper;

        public BasketElementsRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public override async Task<Core.Models.Entities.BasketElement> Get(Guid id)
        {
            var entity = await _Context.Set<BasketElement>()
                .Include(x => x._Good)
                    .ThenInclude(x => x._GoodSubtype)
                        .ThenInclude(x => x._GoodType)
                .Include(x => x._Size)
                    .ThenInclude(x => x._GoodSubtype)
                .Include(x => x._User)
                .Include(x => x._Discount)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _Mapper.Map<Core.Models.Entities.BasketElement>(entity);
        }

        public override IQueryable<Core.Models.Entities.BasketElement> GetAll(IList<ComplexFilter> filters)
        {
            var result = _Context.Set<BasketElement>()
                .Include(x => x._Good)
                    .ThenInclude(x => x._GoodSubtype)
                        .ThenInclude(x => x._GoodType)
                .Include(x => x._Size)
                    .ThenInclude(x => x._GoodSubtype)
                .Include(x => x._User)
                .Include(x => x._Discount)
                .AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return _Mapper.ProjectTo<Core.Models.Entities.BasketElement>(result);
        }
    }
}
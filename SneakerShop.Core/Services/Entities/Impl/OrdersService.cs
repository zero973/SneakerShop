using AutoMapper;
using SneakerShop.Core.Enums.Web;
using SneakerShop.Core.Models.Auth;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Services.Auth;
using SneakerShop.Core.Services.Impl;
using SneakerShop.DataAdapters.Contracts.Repositories.Intf;

namespace SneakerShop.Core.Services.Entities.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class OrdersService : BaseEntityService<Order, DataAdapters.Contracts.Models.Entities.Order>, IOrdersService
    {

        private readonly IDbEntitiesRepository DbRepository;

        private readonly IAutificationService _AutificationService;

        private readonly IMapper _Mapper;

        private readonly IBasketService _BasketService;

        public OrdersService(IDbEntitiesRepository dbRepository, IAutificationService autificationService, 
            IMapper mapper, IBasketService basketService)
            : base(dbRepository, autificationService, mapper)
        {
            DbRepository = dbRepository;
            _AutificationService = autificationService;
            _Mapper = mapper;
            _BasketService = basketService;
        }

        public async Task<Result> MakeOrderFromBasket()
        {
            var user = await GetCurrentUser();
            if (user == null)
                return new Result(false, null, "Пользователь не авторизован");

            var order = new Order()
            {
                _User = user,
                Status = DataAdapters.Contracts.Enums.OrderStatuses.Prepearing
            };

            var filter = new ComplexFilter() { Field = "UserId", Operator = ComplexFilterOperators.Equals, Value = user.Id };
            var baseParams = new BaseListParams() 
            {
                PageNumber = 1,
                RowsCount = 1,
                Filters = new List<ComplexFilter>() { filter }
            };
            var data = await _BasketService.GetActuals(baseParams);
            var basket = data.Data as List<BasketElement>;
            var orderedGoods = basket.Select(x => new OrderedGood() 
            { 
                _Order = order,
                _Good = x._Good,
                _Size = x._Size,
                _Discount = x._Discount,
                Count = x.Count
            }).ToList();

            // добавить сам order

            // foreach - добавить OrderedGood либо создать AddRange 

            return new Result();
        }

        private async Task<AppUser?> GetCurrentUser()
        {
            var data = await _AutificationService.GetCurrentUser();
            return data.Data as AppUser;
        }

    }
}
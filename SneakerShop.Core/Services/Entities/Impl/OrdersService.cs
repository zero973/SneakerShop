﻿using SneakerShop.Core.Enums;
using SneakerShop.Core.Enums.Web;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Impl;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Entities.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class OrdersService : BaseEntityService<Order>, IOrdersService
    {

        private readonly IDbEntitiesRepository<Order> DbRepository;

        private readonly IAuthenticationService _AuthenticationService;

        private readonly IBasketService _BasketService;

        public OrdersService(IDbEntitiesRepository<Order> dbRepository, IAuthenticationService authenticationService) 
            : base(dbRepository, authenticationService)
        {
            DbRepository = dbRepository;
        }

        public async Task<Result<Order>> MakeOrderFromBasket()
        {
            var user = await GetCurrentUser();
            if (user == null)
                return new Result<Order>(false, null, "Пользователь не авторизован");

            var order = new Order()
            {
                User = user,
                Status = OrderStatuses.Prepearing
            };

            var baseParams = new BaseListParams() 
            {
                PageNumber = -1,
                RowsCount = -1,
                Filters = new List<ComplexFilter>() 
                {
                    new ComplexFilter() { Field = "UserId", Operator = ComplexFilterOperators.Equals, Value = user.Id },
                    new ComplexFilter() { Field = "IsActual", Operator = ComplexFilterOperators.Equals, Value = true }
                }
            };
            var data = await _BasketService.GetAll(baseParams);
            var basket = data.Data as List<BasketElement>;
            var orderedGoods = basket.Select(x => new OrderedGood() 
            { 
                Order = order,
                Good = x.Good,
                Size = x.Size,
                Discount = x.Discount,
                Count = x.Count
            }).ToList();

            // todo добавить сам order

            // foreach - добавить OrderedGood либо создать AddRange 

            return new Result<Order>();
        }

        private async Task<AppUser?> GetCurrentUser()
        {
            var data = await _AuthenticationService.GetCurrentUser();
            return data.Data as AppUser;
        }

    }
}
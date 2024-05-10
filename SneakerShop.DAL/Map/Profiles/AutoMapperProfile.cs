﻿using AutoMapper;

namespace SneakerShop.DAL.Map.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Core.Models.Entities.AppUser, Models.Entities.AppUser>()
                .ReverseMap();

            CreateMap<Core.Models.Entities.BasketElement, Models.Entities.BasketElement>()
                .ForPath(x => x._Good._GoodSubtype, x => x.Ignore())
                .ForPath(x => x._Size._GoodSubtype, x => x.Ignore())
                .ForPath(x => x._User.Basket, x => x.Ignore())
                .ReverseMap();

            CreateMap<Core.Models.Entities.Discount, Models.Entities.Discount>()
                .ForPath(x => x._Good._GoodSubtype, x => x.Ignore())
                .ForPath(x => x.BasketElements, x => x.Ignore())
                .ForPath(x => x.OrderedGoods, x => x.Ignore())
                .ReverseMap();

            CreateMap<Core.Models.Entities.DiscountType, Models.Entities.DiscountType>()
                .ReverseMap();

            CreateMap<Core.Models.Entities.Good, Models.Entities.Good>()
                .ForPath(x => x._GoodSubtype._GoodType, x => x.Ignore())
                .ForPath(x => x.BasketElements, x => x.Ignore())
                .ForPath(x => x.OrderedGoods, x => x.Ignore())
                .ForPath(x => x.Discounts, x => x.Ignore())
                .ReverseMap();

            CreateMap<Core.Models.Entities.GoodSubtype, Models.Entities.GoodSubtype>()
                .ForPath(x => x.Goods, x => x.Ignore())
                .ForPath(x => x.Sizes, x => x.Ignore())
                .ReverseMap();

            CreateMap<Core.Models.Entities.GoodType, Models.Entities.GoodType>()
                .ReverseMap();

            CreateMap<Core.Models.Entities.Manufacturer, Models.Entities.Manufacturer>()
                .ReverseMap();

            CreateMap<Core.Models.Entities.Order, Models.Entities.Order>()
                .ReverseMap();

            CreateMap<Core.Models.Entities.OrderedGood, Models.Entities.OrderedGood>()
                .ForPath(x => x._Good._GoodSubtype, x => x.Ignore())
                .ForPath(x => x._Size._GoodSubtype, x => x.Ignore())
                .ForPath(x => x._Discount._Good, x => x.Ignore())
                .ReverseMap();

            CreateMap<Core.Models.Entities.Size, Models.Entities.Size>()
                .ForPath(x => x._GoodSubtype._GoodType, x => x.Ignore())
                .ReverseMap();
        }
    }
}
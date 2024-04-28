﻿using Microsoft.AspNetCore.Identity;
using SneakerShop.Core.Models.Entities;

namespace SneakerShop.Core.Models.Auth
{
    /// <summary>
    /// Пользователь в системе SneakerShop
    /// </summary>
    public class AppUser : IdentityUser<Guid>
    {

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Заказы пользователя
        /// </summary>
        public ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Товары в корзине пользователя
        /// </summary>
        public ICollection<BasketElement> Basket { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string Role { get; set; }

    }
}
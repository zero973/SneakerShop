using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerShop.DataAdapters.Models.Entities
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
        /// Роли пользователя
        /// </summary>
        [NotMapped]
        public ICollection<string> Roles { get; set; }

        /// <summary>
        /// Заказы пользователя
        /// </summary>
        public ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Товары в корзине пользователя
        /// </summary>
        public ICollection<BasketElement> Basket { get; set; }

    }
}
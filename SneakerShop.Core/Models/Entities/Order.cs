using SneakerShop.DataAdapters.Contracts.Enums;
using SneakerShop.DataAdapters.Contracts.Models.Entities;

namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Заказ
	/// </summary>
	public class Order : BaseEntity
	{

        public Guid UserId { get; set; }

        public Auth.AppUser _User { get; set; }

        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatuses Status { get; set; }

        /// <summary>
        /// Товары в заказе
        /// </summary>
        public ICollection<OrderedGood> OrderedGoods { get; set; }

        public Order()
		{

		}

        public Order(Guid userId, OrderStatuses status)
        {
            UserId = userId;
            Status = status;
        }

        public override string ToString()
		{
			return $"Id: {Id}, Status: {Status}, UserId: {UserId}";
		}

	}
}
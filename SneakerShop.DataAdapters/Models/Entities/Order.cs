using SneakerShop.Core.Enums;

namespace SneakerShop.DataAdapters.Models.Entities
{
	/// <summary>
	/// Заказ
	/// </summary>
	public class Order : BaseEntity
	{

        public Guid UserId { get; set; }

        public AppUser _User { get; set; }

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
			return $"Id: {Id}, UserId: {UserId}, Status: {Status}";
		}

	}
}
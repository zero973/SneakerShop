namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Заказанный товар вместе с размером и скидкой
	/// </summary>
	public class OrderedGood : BaseEntity
    {

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public Guid GoodId { get; set; }

        public Good Good { get; set; }

        public Guid SizeId { get; set; }

        public Size Size { get; set; }

        public Guid? DiscountId { get; set; }

        public Discount? Discount { get; set; }

        public int Count { get; set; }

		public OrderedGood()
		{

		}

        public override string ToString()
		{
			return $"Id: {Id}, Good: {Good.Name}, Size: {Size.Name}, Count: {Count}, Order: {Order.Id}";
		}

	}
}
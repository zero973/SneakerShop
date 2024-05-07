namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Заказанный товар вместе с размером и скидкой
	/// </summary>
	public class OrderedGood : BaseEntity
    {

        public Guid OrderId { get; set; }

        public Order _Order { get; set; }

        public Guid GoodId { get; set; }

        public Good _Good { get; set; }

        public Guid SizeId { get; set; }

        public Size _Size { get; set; }

        public Guid? DiscountId { get; set; }

        public Discount? _Discount { get; set; }

        public int Count { get; set; }

		public OrderedGood()
		{

		}

        public override string ToString()
		{
			return $"Id: {Id}, Good: {_Good.Name}, Size: {_Size.Name}, Count: {Count}, Order: {_Order.Id}";
		}

	}
}
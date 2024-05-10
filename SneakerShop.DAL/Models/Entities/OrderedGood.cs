namespace SneakerShop.DAL.Models.Entities
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

        public OrderedGood(Guid orderId, Guid goodId, Guid sizeId, Guid? discountId, int count)
        {
            OrderId = orderId;
            GoodId = goodId;
            SizeId = sizeId;
            DiscountId = discountId;
            Count = count;
        }

        public override string ToString()
		{
			return $"Id: {Id}, OrderId: {OrderId}, GoodId: {GoodId}, SizeId: {SizeId}, Count: {Count}";
		}

	}
}
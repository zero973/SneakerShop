using SneakerShop.DataAdapters.Contracts.Models.Entities;

namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Заказанный товар вместе с размером и скидкой
	/// </summary>
	public class OrderedGood : BaseEntity
    {

        public Order _Order { get; set; }

        public Good _Good { get; set; }

        public Size _Size { get; set; }

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
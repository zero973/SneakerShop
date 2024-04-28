namespace SneakerShop.Core.Models.Entities
{
    /// <summary>
    /// Добавленный в корзину товар
    /// </summary>
    public class BasketElement : BaseEntity
	{

        public Good _Good { get; set; }

        public Size _Size { get; set; }

        public AppUser _User { get; set; }

        public Discount? _Discount { get; set; }

        public int Count { get; set; }

		public BasketElement()
		{

		}

        public override string ToString()
		{
			return $"Id: {Id}, Good: {_Good.Name}, Size: {_Size.Name}, Count: {Count}, UserId: {_User.Id}";
		}

	}
}
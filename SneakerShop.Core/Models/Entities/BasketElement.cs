namespace SneakerShop.Core.Models.Entities
{
    /// <summary>
    /// Добавленный в корзину товар
    /// </summary>
    public class BasketElement : BaseEntity
	{

        public Guid GoodId { get; set; }

        public Good? Good { get; set; }

        public Guid SizeId { get; set; }

        public Size? Size { get; set; }

        public Guid UserId { get; set; }

        public AppUser? User { get; set; }

        public Guid? DiscountId { get; set; }

        public Discount? Discount { get; set; }

        public int Count { get; set; }

		public BasketElement()
		{

		}

        public override string ToString()
		{
			return $"Id: {Id}, Good: {Good.Name}, Size: {Size.Name}, Count: {Count}, UserId: {User.Id}";
		}

	}
}
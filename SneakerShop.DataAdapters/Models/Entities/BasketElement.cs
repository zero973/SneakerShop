using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerShop.DataAdapters.Models.Entities
{
    /// <summary>
    /// Добавленный в корзину товар
    /// </summary>
    [Table("Baskets")]
    public class BasketElement : BaseEntity
	{

        public Guid GoodId { get; set; }

        public Good? _Good { get; set; }

        public Guid SizeId { get; set; }

        public Size? _Size { get; set; }

        public Guid UserId { get; set; }

        public AppUser? _User { get; set; }

        public Guid? DiscountId { get; set; }

        public Discount? _Discount { get; set; }

        public int Count { get; set; }

		public BasketElement()
		{

		}

        public BasketElement(Guid goodId, Guid sizeId, Guid userId, Guid? discountId, int count)
        {
            GoodId = goodId;
            SizeId = sizeId;
            UserId = userId;
            DiscountId = discountId;
            Count = count;
        }

        public override string ToString()
		{
			return $"Id: {Id}, GoodId: {GoodId}, SizeId: {SizeId}, UserId: {UserId}, Count: {Count}";
		}

	}
}
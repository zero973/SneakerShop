using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerShop.DataAdapters.Contracts.Models.Entities
{
	/// <summary>
	/// Дейсвующая скидка на определённом товаре
	/// </summary>
	public class Discount : BaseEntity
    {

        public Guid GoodId { get; set; }

        public Good? _Good { get; set; }

        public Guid DiscountTypeId { get; set; }

        public DiscountType? _DiscountType { get; set; }

        /// <summary>
        /// Дата начала действия скидки
        /// </summary>
        [Column(TypeName = "timestamp without time zone")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата начала окончания скидки
        /// </summary>
        [Column(TypeName = "timestamp without time zone")]
        public DateTime EndDate { get; set; }

        public ICollection<OrderedGood> OrderedGoods { get; set; }

        public ICollection<BasketElement> BasketElements { get; set; }

        public Discount()
		{

		}

        public Discount(Guid goodId, Guid discountTypeId, DateTime startDate, DateTime endDate)
        {
            GoodId = goodId;
            DiscountTypeId = discountTypeId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
		{
			return $"Id: {Id}, GoodId: {GoodId}, DiscountTypeId: {DiscountTypeId}, StartDate: {StartDate.ToShortDateString()}, EndDate: {EndDate.ToShortDateString()}";
		}

	}
}
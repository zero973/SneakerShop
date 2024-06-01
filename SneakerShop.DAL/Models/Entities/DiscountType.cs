using System.ComponentModel.DataAnnotations;

namespace SneakerShop.DAL.Models.Entities
{
	/// <summary>
	/// Тип скидки
	/// </summary>
	public class DiscountType : BaseEntity
	{

		[MaxLength(200)]
        public string Name { get; set; }

		[MaxLength(200)]
        public string Description { get; set; }

        public int Percent { get; set; }

		public ICollection<Discount> Discounts { get; set; }

		public DiscountType()
		{

		}

		public DiscountType(string name, string description, int percent)
		{
			Name = name;
			Description = description;
			Percent = percent;
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Description: {Description}, Percent: {Percent}";
		}

	}
}
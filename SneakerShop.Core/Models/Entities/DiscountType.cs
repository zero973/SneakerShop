namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Тип скидки
	/// </summary>
	public class DiscountType : BaseEntity
	{

        public string Name { get; set; }

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
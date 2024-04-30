namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Товар
	/// </summary>
	public class Good : BaseEntity
	{

        public GoodSubtype _GoodSubtype { get; set; }

        public Manufacturer _Manufacturer { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public ICollection<Discount> Discounts { get; set; }

        public Good()
		{

		}

        public override string ToString()
		{
			return $"Id: {Id}, GoodSubtype: {_GoodSubtype.Name}, Manufacturer: {_Manufacturer.Name}, Name: {Name}, Price: {Price}, Description: {Description}, ImageURL: {ImageURL}";
		}

	}
}
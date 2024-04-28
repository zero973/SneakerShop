namespace SneakerShop.DataAdapters.Contracts.Models.Entities
{
	/// <summary>
	/// Тип товара (одежда, обувь, аксессуары)
	/// </summary>
	public class GoodType : BaseEntity
	{

        public string Name { get; set; }

		public ICollection<GoodSubtype> GoodSubtypes { get; set; }

		public GoodType()
		{

		}

		public GoodType(string name)
		{
			Name = name;
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}";
		}

	}
}
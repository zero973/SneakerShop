namespace SneakerShop.DataAdapters.Contracts.Models.Entities
{
	/// <summary>
	/// Производитель
	/// </summary>
	public class Manufacturer : BaseEntity
	{

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Good> Goods { get; set; }

        public Manufacturer()
		{
			
		}

		public Manufacturer(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Description: {Description}";
		}

	}
}
namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Производитель
	/// </summary>
	public class Manufacturer : BaseEntity
	{

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

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
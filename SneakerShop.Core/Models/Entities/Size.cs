namespace SneakerShop.Core.Models.Entities
{
    /// <summary>
	/// Размер товара
	/// </summary>
    public class Size : BaseEntity
    {

        public Guid GoodSubtypeId { get; set; }

        public GoodSubtype GoodSubtype { get; set; }

        public string Name { get; set; }

        public Size()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, GoodSubtype: {GoodSubtype.Name}";
        }
    }
}
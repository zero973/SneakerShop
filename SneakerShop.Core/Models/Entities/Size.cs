namespace SneakerShop.Core.Models.Entities
{
    /// <summary>
	/// Размер товара
	/// </summary>
    public class Size : BaseEntity
    {

        public GoodSubtype _GoodSubtype { get; set; }

        public string Name { get; set; }

        public Size()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, GoodSubtype: {_GoodSubtype.Name}";
        }
    }
}
namespace SneakerShop.DataAdapters.Contracts.Models.Entities
{
    /// <summary>
	/// Размер товара
	/// </summary>
    public class Size : BaseEntity
    {

        public Guid GoodSubtypeId { get; set; }

        public GoodSubtype? _GoodSubtype { get; set; }

        public string Name { get; set; }

        public ICollection<OrderedGood> OrderedGoods { get; set; }

        public ICollection<BasketElement> BasketElements { get; set; }

        public Size()
        {

        }

        public Size(Guid goodSubtypeId, string name)
        {
            GoodSubtypeId = goodSubtypeId;
            Name = name;
        }

        public override string ToString()
        {
            return $"Id: {Id}, GoodSubtypeId: {GoodSubtypeId}, Name: {Name}";
        }
    }
}
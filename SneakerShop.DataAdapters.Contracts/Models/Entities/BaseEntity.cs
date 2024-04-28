using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerShop.DataAdapters.Contracts.Models.Entities
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public abstract class BaseEntity : IEntity
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsActual { get; set; } = true;

        public Guid? CreatedUserId { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Guid? UpdatedUserId { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime? UpdateDate { get; set; }

        public Guid? DeletedUserId { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime? DeleteDate { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} IsActual: {IsActual}";
        }

        public override bool Equals(object? obj)
        {
            var other = obj as BaseEntity;
            return Id == other?.Id;
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Categories { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }

    }
}

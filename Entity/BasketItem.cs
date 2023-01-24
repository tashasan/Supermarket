
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class BasketItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

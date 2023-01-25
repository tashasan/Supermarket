using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Basket : BaseEntity
    {
        public bool isSold { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
